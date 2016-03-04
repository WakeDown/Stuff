using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Helpers;
using DALCoordination;
using DALCoordination.Entities;
using DALStuff.Models;
using Microsoft.Ajax.Utilities;
using Document = DALCoordination.Entities.Document;


namespace Stuff.Services
{
    public static class RequestConstants
    {
        public static int RequestStatusNewId = 1;
        public static int RequestStatusCoordinateId = 2;
        public static int RequestStatusNotCoordinateId = 3;
        public static int RequestStatusInWorkId = 4;
        public static int RequestStatusClosedId = 5;
    }

    public class RequestService
    {
        private static string PrivateStuffConnectionString { get; set; }
        private static string StuffConnectionString {
            get
            {
                if (string.IsNullOrWhiteSpace(PrivateStuffConnectionString))
                    PrivateStuffConnectionString = ConfigurationManager.ConnectionStrings["StuffConnectionString"].ConnectionString + ";Password=sa";

                return PrivateStuffConnectionString;
            }
        }
        private static string PrivateCoordinationConnectionString { get; set; }
        private static string CoordinationConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PrivateCoordinationConnectionString))
                    PrivateCoordinationConnectionString = ConfigurationManager.ConnectionStrings["CoordinationDbContext"].ConnectionString + ";Password=sa";

                return PrivateCoordinationConnectionString;
            }
        }
        public static IEnumerable<Models.Request> GetReguestsList(out int totalCnt, Expression<Func<request, bool>> pred, int page, int pagwSize)
        {

            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                totalCnt = stuffDB.requests.Count(pred);
                int maxPage = (totalCnt%pagwSize == 0) ? (totalCnt%pagwSize) : (totalCnt%pagwSize + 1);
                if (page > maxPage + 1)
                    page = maxPage;

                var nativeList = stuffDB.requests.Where(pred).OrderByDescending(it=>it.Id).Skip((page - 1) * pagwSize).Take(pagwSize).ToList();
                return nativeList.Select(src => RequestMapper.MapRequestToListModel(src)).ToList();
            }
        }
        public static IEnumerable<Models.BaseDictionary> GetReguestPositionList()
        {
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                return stuffDB.positions.Where(it=>it.enabled)
                    .Select(src => new Models.BaseDictionary { id = src.id, name = src.name }).ToList();
            }
        }
        public static IEnumerable<Models.BaseDictionary> GetReguestReasonList()
        {
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                return stuffDB.request_reasons.Where(it => it.Enabled)
                    .Select(src => new Models.BaseDictionary { id = src.Id, name = src.Name }).ToList();
            }
        }
        public static IEnumerable<Models.EmployeeToCombo> GetEmployeeList()
        {
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                return stuffDB.employees_view
                    .Select(src => new Models.EmployeeToCombo { ad_sid = src.ad_sid, name = src.full_name }).ToList();
            }
        }
        public static IEnumerable<Models.BaseDictionary> GetDepartmentList()
        {
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                return stuffDB.departments.Where(it => it.enabled)
                    .Select(src => new Models.BaseDictionary { id = src.id, name = src.name }).ToList();
            }
        }
        public static Models.Request GetReguest(int id)
        {
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                return RequestMapper.MapRequestToModel(stuffDB.requests.First(it => it.Enabled && it.Id == id));
            }
        }
        public static int CreateRequest(Models.Request model, string creatorSid)
        {
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                var newRequest = RequestMapper.MapRequestToEntity(model);
                newRequest.LastChangeDatetime = DateTime.Now;
                newRequest.CreateDatetime = DateTime.Now;
                newRequest.IdStatus = RequestConstants.RequestStatusNewId;
                newRequest.HaveCoordination = false;
                newRequest.Enabled = true;
                stuffDB.requests.Add(newRequest);

                stuffDB.SaveIfNoError();
                return newRequest.Id;
            }
        }
        public static bool DeleteRequest(int id, string deletorSid)
        {
            return true;
        }
        public static void CreateNewCoordination(Models.CoordinationDocumentTypes type, int docId, string creatorSid)
        {
            if (type == Models.CoordinationDocumentTypes.Request)
                CreateNewRequestCoordination(docId, creatorSid);
        }
        public static void CreateNewRequestCoordination(int docId, string creatorSid)
        {
            if (docId <= 0 || string.IsNullOrWhiteSpace(creatorSid))
                throw new Exception("Неверные параметры для создания согласования в CreateNewRequestCoordination()");

            var linkModel = new Models.JsonDocumentLinkType
            {
                Type = Models.CoordinationDocumentTypes.Request,
                ConnString = ConfigurationManager.ConnectionStrings["StuffConnectionString"].ConnectionString,
                DocId = docId
            };
            String link = Json.Encode(linkModel);
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                using (CoordinationContext coordinationDB = new CoordinationContext(CoordinationConnectionString))
                {
                    var coordDocuments = coordinationDB.Documents;
                    /*  создаем исполнение и связываем его с документом coorddoc 
                        находим тип документа согдасования doctype 
                        через который будет связана схема согласования с coorddoc*/
                    var execution = new WfwDocumentExecution
                    {
                        StartDate = DateTimeOffset.Now,
                        CreaterSid = creatorSid,
                        Level = 0,
                    };
                    var docType = coordinationDB.DocumentTypes.First(it => it.Name == Models.CoordinationDocumentTypes.Request.ToString() && it.Enabled);

                    var coordDoc = new Document
                    {
                        DocumentType = docType,
                        WfwDocumentExecution = execution,
                        Name = "Согласование заявки на подбор персонала №" + docId,
                        Id = Models.CoordinationDocumentTypes.Request + ":" + docId,
                        LinkToDoc = link,
                        LinkToDocId = docId,
                    };
                    coordDocuments.Add(coordDoc);

                    /*заполняем таблицу для всего процесса согласования на основе шаблона - схемы*/
                    coordinationDB.WfwSchemeStages
                        .Where(it => it.Enabled && it.SchemeId == docType.SchemeId)
                        .OrderBy(it=>it.Level)
                        .ForEach(it => coordinationDB.WfwDocumentWorkStages.Add(
                            new WfwDocumentWorkStages
                            {
                               WfwDocumentExecution = execution,
                               Level = it.Level,
                               EmployeeRole = it.EmployeeRole,
                               Coordinator = it.Coordinator,
                            }));
                    
                    var requestDoc = stuffDB.requests.First(it => it.Id == docId && it.Enabled);
                    requestDoc.HaveCoordination = true;
                    requestDoc.IdStatus = RequestConstants.RequestStatusInWorkId;

                    stuffDB.SaveIfNoError();
                    coordinationDB.SaveIfNoError();
                }
            }
        }
        public static void ProcessRestartCoordination(Models.CoordinationDocumentTypes type, int docId, string creatorSid)
        {
            if (type == Models.CoordinationDocumentTypes.Request)
                ProcessRequestRestartCoordination(docId, creatorSid);
        }
        public static void ProcessRequestRestartCoordination(int docId, string creatorSid)
        {
            using (CoordinationContext coordinationDB = new CoordinationContext(CoordinationConnectionString))
            {
                using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
                {
                    var linkModel = new Models.JsonDocumentLinkType
                    {
                        Type = Models.CoordinationDocumentTypes.Request,
                        ConnString = ConfigurationManager.ConnectionStrings["StuffConnectionString"].ConnectionString,
                        DocId = docId
                    };
                    String link = Json.Encode(linkModel);
                    var doc = coordinationDB.Documents.Single(it => it.Enabled &&
                        it.LinkToDocId == docId && it.LinkToDoc == link);
                    var execution = doc.WfwDocumentExecution;
                    var continueFromLastStage = doc.DocumentType.WfwScheme.ContinueLastStage;

                    if (continueFromLastStage)
                    {
                        var schemesToRevert = execution.WfwDocumentWorkSchemes.Where(it => it.Enabled
                            && it.Level == execution.Level && it.WfwEventResult != null && !it.WfwEventResult.Success);
                        schemesToRevert.All(it =>
                        {
                            it.Date = null;
                            it.WfwEventResult = null;
                            it.Comment = null;
                            return true;
                        });
                    }
                    else
                    {
                        var schemesToRevert = execution.WfwDocumentWorkSchemes.Where(it => it.Enabled);
                        schemesToRevert.All(it =>
                        {
                            it.Date = null;
                            it.ResultId = null;
                            it.Comment = null;
                            return true;
                        });
                        execution.Level = 0;
                    }
                    
                    var request = stuffDB.requests.First(it => it.Enabled && it.Id == docId);
                    request.IdStatus = RequestConstants.RequestStatusInWorkId;
                    request.CoordinationPaused = false;

                    coordinationDB.SaveIfNoError();
                    stuffDB.SaveIfNoError();
                }
            }
        }
    }
}