using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CoordinationDB;
using DALStuff.Models;
using Stuff.Models;

namespace Stuff.Services
{
    public static class Constants
    {
        public static int RequestStatus_New_Id = 1;
        public static int RequestStatus_Coordinate_Id = 2;
        public static int RequestStatus_NotCoordinate_Id = 3;
        public static int RequestStatus_InWork_Id = 4;
        public static int RequestStatus_Closed_Id = 5;

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
            List<Models.Request> result;
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                var nativeList = stuffDB.requests.Where(pred).OrderByDescending(it=>it.Id).Skip((page - 1) * pagwSize).Take(pagwSize).ToList();
                result = nativeList.Select(src => RequestMapper.MapRequestToModel(src)).ToList();
                totalCnt = stuffDB.requests.Count(pred);
            }

            return result;
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
        public static IEnumerable<Models.BaseDictionary> GetEmployeeList()
        {
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                return stuffDB.employees.Where(it => it.enabled)
                    .Select(src => new Models.BaseDictionary { id = src.id, name = src.full_name }).ToList();
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
                newRequest.IdStatus = Constants.RequestStatus_New_Id;
                newRequest.HaveCoordination = false;
                newRequest.Enabled = true;
                stuffDB.requests.Add(newRequest);


                string errMsg = "";
                if (stuffDB.GetValidationErrors().Any())
                {
                    errMsg = stuffDB.GetValidationErrors().SelectMany(
                        validationResults => validationResults.ValidationErrors)
                        .Aggregate(errMsg, (current, error) => current + string.Format("Entity Property: {0}, Error {1}", error.PropertyName, error.ErrorMessage));

                    throw new Exception(errMsg);
                }
                else
                {
                    stuffDB.SaveChanges();
                }
                return newRequest.Id;
            }
        }
        public static bool DeleteRequest(int id, string deletorSid)
        {
            return true;
        }
        public static void CreateNewCoordination(CoordinationDocumentTypes type, int? docId, string creatorSid)
        {
            if (type == CoordinationDocumentTypes.Request)
                CreateNewRequestCoordination(docId, creatorSid);
        }
        public static void CreateNewRequestCoordination(int? docId, string creatorSid)
        {
            if (!docId.HasValue || string.IsNullOrWhiteSpace(creatorSid))
                throw new Exception("Неверные параметры для создания согласования в CreateNewRequestCoordination()");

            StringBuilder linkSB = new StringBuilder("{Type:" + (int) CoordinationDocumentTypes.Request);
            linkSB.Append(",ConnString:\"" + StuffConnectionString + "\"");
            linkSB.Append(",DocId:" + docId.Value);
            linkSB.Append("}");
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                using (CoordinationContext coordinationDB = new CoordinationContext(CoordinationConnectionString))
                {
                    var coordDocuments = coordinationDB.Documents;
                    //var creator = coordinationDB.Employees.First(employee => employee.AdSid == creatorSid);

                    var execution = new DAL.Entities.Models.WfwDocumentExecution
                    {
                        StartDate = DateTime.Now,
                        CreaterSid = creatorSid,
                        Level = 0,
                    };
                    var docType = coordinationDB.DocumentTypes.First(it => it.Name == CoordinationDocumentTypes.Request.ToString() && it.Enabled);

                    var coordDoc = new DAL.Entities.Models.Document
                    {
                        DocumentType = docType,
                        WfwDocumentExecution = execution,
                        Name = "Согласование заявки на подбор персонала №" + docId.Value,
                        Id = CoordinationDocumentTypes.Request.ToString() + docId.Value,
                        LinkToDoc = linkSB.ToString(),
                        LinkToDocId = docId.Value,
                    };
                    coordDocuments.Add(coordDoc);

                    string errMsg = "";
                    if (coordinationDB.GetValidationErrors().Any())
                    {
                        errMsg = coordinationDB.GetValidationErrors().SelectMany(
                            validationResults => validationResults.ValidationErrors)
                            .Aggregate(errMsg, (current, error) => current + string.Format("Entity Property: {0}, Error {1}", error.PropertyName, error.ErrorMessage));

                        throw new Exception(errMsg);
                    }
                    else
                    {
                        coordinationDB.SaveChanges();
                    }

                    var requestDoc = stuffDB.requests.First(it => it.Id == docId.Value && it.Enabled);
                    requestDoc.HaveCoordination = true;

                    errMsg = "";
                    if (stuffDB.GetValidationErrors().Any())
                    {
                        errMsg = stuffDB.GetValidationErrors().SelectMany(
                            validationResults => validationResults.ValidationErrors)
                            .Aggregate(errMsg, (current, error) => current + string.Format("Entity Property: {0}, Error {1}", error.PropertyName, error.ErrorMessage));

                        throw new Exception(errMsg);
                    }
                    else
                    {
                        stuffDB.SaveChanges();
                    }
                }
            }
        }
    }
}