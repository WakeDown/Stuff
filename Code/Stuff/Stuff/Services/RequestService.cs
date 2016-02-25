using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using DALStuff.Models;

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
        private static string PrivateConnectionString { get; set; }

        private static string ConnectionString {
            get
            {
                if (string.IsNullOrWhiteSpace(PrivateConnectionString))
                    PrivateConnectionString = ConfigurationManager.ConnectionStrings["StuffConnectionString"].ConnectionString + ";Password=sa";

                return PrivateConnectionString;
            }
        }

        public static IEnumerable<Models.Request> GetReguestsList(out int totalCnt, Expression<Func<request, bool>> pred, int page, int pagwSize)
        {
            List<Models.Request> result;
            using (StuffContext db = new StuffContext(ConnectionString))
            {
                var nativeList = db.requests.Where(pred).ToList();
                result = nativeList.Select(src => RequestMapper.MapRequestToModel(src, null)).Skip((page - 1)* pagwSize).Take(pagwSize).ToList();
                totalCnt = db.requests.Count(pred);
            }

            return result;
        }
        public static IEnumerable<Models.BaseDictionary> GetReguestPositionList()
        {
            using (StuffContext db = new StuffContext(ConnectionString))
            {
                return db.positions.Where(it=>it.enabled)
                    .Select(src => new Models.BaseDictionary { id = src.id, name = src.name }).ToList();
            }
        }
        public static IEnumerable<Models.BaseDictionary> GetReguestReasonList()
        {
            using (StuffContext db = new StuffContext(ConnectionString))
            {
                return db.request_reasons.Where(it => it.Enabled)
                    .Select(src => new Models.BaseDictionary { id = src.Id, name = src.Name }).ToList();
            }
        }
        public static IEnumerable<Models.BaseDictionary> GetEmployeeList()
        {
            using (StuffContext db = new StuffContext(ConnectionString))
            {
                return db.employees.Where(it => it.enabled)
                    .Select(src => new Models.BaseDictionary { id = src.id, name = src.full_name }).ToList();
            }
        }
        public static IEnumerable<Models.BaseDictionary> GetDepartmentList()
        {
            using (StuffContext db = new StuffContext(ConnectionString))
            {
                return db.departments.Where(it => it.enabled)
                    .Select(src => new Models.BaseDictionary { id = src.id, name = src.name }).ToList();
            }
        }

        public static int CreateRequest(Models.Request model, string creatorSid)
        {
            using (StuffContext db = new StuffContext(ConnectionString))
            {
                var newRequest = RequestMapper.MapRequestToEntity(model, null);
                newRequest.LastChangeDatetime = DateTime.Now;
                newRequest.CreateDatetime = DateTime.Now;
                newRequest.IdStatus = Constants.RequestStatus_New_Id;
                newRequest.Enabled = true;
                db.requests.Add(newRequest);


                string errMsg = "";
                if (db.GetValidationErrors().Any())
                {
                    errMsg = db.GetValidationErrors().SelectMany(
                        validationResults => validationResults.ValidationErrors)
                        .Aggregate(errMsg, (current, error) => current + string.Format("Entity Property: {0}, Error {1}", error.PropertyName, error.ErrorMessage));

                    throw new Exception(errMsg);
                }
                else
                {
                    db.SaveChanges();
                }
                return newRequest.Id;
            }
        }

        public static bool DeleteRequest(int id, string deletorSid)
        {
            return true;
        }

    }
}