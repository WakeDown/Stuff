using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Helpers;
using DALCoordination;
using DALCoordination.Entities;
using DALStuff.Models;
using Stuff.Models;


namespace Stuff.Services
{
    public static class CoordinationConstants
    {
        public static int WfwEventResultApproveId = 1;
        public static int WfwEventResultRevisionId = 2;
        public static int WfwEventResultDismissId = 3;
    }

    public class CoordinationService
    {
        private static string PrivateStuffConnectionString { get; set; }

        private static string StuffConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PrivateStuffConnectionString))
                    PrivateStuffConnectionString =
                        ConfigurationManager.ConnectionStrings["StuffEntityConnectionString"].ConnectionString/* + ";Password=sa"*/;

                return PrivateStuffConnectionString;
            }
        }

        private static string PrivateCoordinationConnectionString { get; set; }

        private static string CoordinationConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PrivateCoordinationConnectionString))
                    PrivateCoordinationConnectionString =
                        ConfigurationManager.ConnectionStrings["CoordinationDbContext"].ConnectionString/* + ";Password=sa"*/;

                return PrivateCoordinationConnectionString;
            }
        }

        public static IEnumerable<Coordination> GetCoordinationsList(out int totalCnt,
            Expression<Func<WfwDocumentExecution, bool>> pred, int page, int pagwSize)
        {
            using (CoordinationContext coordinationContext = new CoordinationContext(CoordinationConnectionString))
            {
                totalCnt = coordinationContext.WfwDocumentExecutions.Count(pred);
                int maxPage = (totalCnt % pagwSize == 0) ? (totalCnt % pagwSize) : (totalCnt % pagwSize + 1);
                if (page > maxPage + 1)
                    page = maxPage;

                var nativeList =
                    coordinationContext.WfwDocumentExecutions.Where(pred)
                        .OrderByDescending(it => it.Id)
                        .Skip((page - 1)*pagwSize)
                        .Take(pagwSize)
                        .ToList();
                return nativeList.Select(src => CoordinationMapper.MapCoordinationToModel(src)).ToList();
            }
        }

        public static Coordination GetCoordination(int id)
        {
            using (CoordinationContext coordinationContext = new CoordinationContext(CoordinationConnectionString))
            {
                return
                    CoordinationMapper.MapCoordinationToModel(
                        coordinationContext.WfwDocumentExecutions.First(it => it.Enabled && it.Id == id));
            }
        }

        public static bool UserNeedCoordinateExecution(string userSid, int executionId)
        {
            using (CoordinationContext coordinationContext = new CoordinationContext(CoordinationConnectionString))
            {
                //Согласование отклонено уже!
                if (coordinationContext.WfwDocumentWorkStages.Any(it => it.Enabled 
                    && it.WfwEventResult != null && !it.WfwEventResult.Success))
                    return false;

                var execution = coordinationContext.WfwDocumentExecutions.First(it => it.Enabled && it.Id == executionId);

                return
                    execution.WfwDocumentWorkSchemes
                    .Any(it => it.Enabled && it.Level == execution.Level
                    && it.WfwEventResult == null
                    &&(it.CoordinatorSid == userSid ||
                    (it.EmployeeRole != null && it.EmployeeRole.EmployeeSid == userSid)));
            }
        }

        public static void ProcessCoordinationWorkflowEvent(int executionId, int resultType, string userSid)
        {
            if (executionId <= 0 || resultType <= 0 || string.IsNullOrWhiteSpace(userSid))
                throw new Exception("Неверные параметры для создания согласования в ProcessCoordinationWorkflowEvent()");

            using (CoordinationContext coordinationDB = new CoordinationContext(CoordinationConnectionString))
            {
                var execution = coordinationDB.WfwDocumentExecutions.SingleOrDefault(it => it.Enabled && it.Id == executionId);
                var workStage = coordinationDB.WfwDocumentWorkStages.First(it => it.Enabled && it.ExecutionId == execution.Id
                    && it.Level == execution.Level && it.ResultId == null
                    && (it.CoordinatorSid == userSid || (it.EmployeeRole != null && it.EmployeeRole.EmployeeSid == userSid)) );
                //var workStage = workStages.First(it => it.ResultId == null);
                workStage.Date = DateTimeOffset.Now;
                workStage.ResultId = resultType;
                workStage.Comment = "Auto generated";
                var executionEvent = new WfwExecutionEvent
                {
                    Date = workStage.Date.Value,
                    Comment = workStage.Comment,
                    ResultId = workStage.ResultId.Value,
                    WfwDocumentWorkStage = workStage,
                    CreaterSid = userSid
                };
                coordinationDB.WfwExecutionEvents.Add(executionEvent);
                coordinationDB.SaveIfNoError();

                if (resultType == CoordinationConstants.WfwEventResultApproveId)
                {
                    ProcessNextStageIfNeed(coordinationDB, execution);
                }
                if (resultType == CoordinationConstants.WfwEventResultRevisionId)
                {
                    ProcessRevisionCoordination(coordinationDB, execution);
                }

                coordinationDB.SaveIfNoError();
            }
        }

        public static int MaxLevelOfExecution(CoordinationContext context, WfwDocumentExecution execution)
        {
            return context.WfwDocumentWorkStages.Where(it => it.Enabled && it.ExecutionId == execution.Id).Max(it => it.Level);
            //context.WfwDocumentExecutions.Where(it => it.Enabled && it.Id == execution.Id).Max(it => it.Level);
        }

        public static void ProcessNextStageIfNeed(CoordinationContext context, WfwDocumentExecution execution)
        {
            var emptyStageExist = context.WfwDocumentWorkStages.Any(it => it.Enabled && it.ExecutionId == execution.Id
                && it.Level == execution.Level && it.ResultId == null);
           /* var stages = context.WfwDocumentWorkStages.Where(it => it.Enabled && it.ExecutionId == execution.Id
                && it.Level == execution.Level).ToList();
            bool emptyStageExist = stages.Any(it=>it.ResultId == null);*/
            // если есть хоть одна ступень на данном уровне которую еще надо согласовать - не переходим на следующий уровень
            if (emptyStageExist)//stages.Any(it=>it.ResultId == null))
                return;

            if (MaxLevelOfExecution(context, execution) == execution.Level)
            {
                var doc = execution.Documents.First(it => it.Enabled);
                JsonDocumentLinkType linkModel = Json.Decode<JsonDocumentLinkType>(doc.LinkToDoc);
                if (linkModel.Type == CoordinationDocumentTypes.Request)
                    FinalRequestCoordination(linkModel, context, execution);
            }
            else
            {
                ++execution.Level;
            }
        }

        public static void FinalRequestCoordination(JsonDocumentLinkType linkModel,CoordinationContext context, WfwDocumentExecution execution)
        {
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                var request = stuffDB.requests.First(it => it.Enabled && it.Id == linkModel.DocId);
                request.IdStatus = RequestConstants.RequestStatusCoordinateId;
                execution.EndDate = DateTimeOffset.Now;

                stuffDB.SaveIfNoError();
            }
        }

        public static void ProcessRevisionCoordination(CoordinationContext context, WfwDocumentExecution execution)
        {
            var doc = execution.Documents.First(it => it.Enabled);
            JsonDocumentLinkType linkModel = Json.Decode<JsonDocumentLinkType>(doc.LinkToDoc);
            if (linkModel.Type == CoordinationDocumentTypes.Request)
                RevisionRequestCoordination(linkModel);
        }

        public static void RevisionRequestCoordination(JsonDocumentLinkType linkModel)
        {
            using (StuffContext stuffDB = new StuffContext(StuffConnectionString))
            {
                var request = stuffDB.requests.First(it => it.Enabled && it.Id == linkModel.DocId);
                request.IdStatus = RequestConstants.RequestStatusNotCoordinateId;
                request.CoordinationPaused = true;

                stuffDB.SaveIfNoError();
            }
        }

    }
}