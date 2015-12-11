using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Newtonsoft.Json;
using Stuff.Objects;

namespace Stuff.Models
{
    public class RestHoliday: DbModel
    {
        public int Id { get; set; }
        public string EmployeeSid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public bool CanEdit { get; set; }
        public bool Confirmed { get; set; }
        public RestHoliday(DateTime startDate, int duration, string employeeSid)
        {
            EmployeeSid = employeeSid;
            StartDate = startDate;
            Duration = duration;
            EndDate = StartDate.AddDays(Duration-1);
            Year = startDate.Year;
        }
        public static List<RestHoliday> GetRestHolidaysForYear(string employeeSid, int year)
        {
            try
            {
                Uri uri = new Uri(string.Format("{0}/RestHoliday/GetList?employeeSid={1}&year={2}",OdataServiceUri,employeeSid,year));
                var jsonList = GetJson(uri);
                return JsonConvert.DeserializeObject<List<RestHoliday>>(jsonList);
            }
            catch (Exception ex)
            {
                return new List<RestHoliday>();
            }
        }
        public static List<RestHoliday> GetRestHolidaysForYear(string employeeSid, int year, out string message)
        {
            try
            {
                Uri uri = new Uri(string.Format("{0}/RestHoliday/GetList?employeeSid={1}&year={2}",OdataServiceUri,employeeSid,year));
                var jsonList = GetJson(uri);
                message = string.Empty;
                return JsonConvert.DeserializeObject<List<RestHoliday>>(jsonList);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return new List<RestHoliday>();
            }
        }
        public static bool Delete(int id, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri(string.Format("{0}/RestHoliday/Close?id={1}",OdataServiceUri,id));
            return PostJson(uri, string.Empty, out responseMessage);
        }

        public bool Save(out ResponseMessage responseMessage)
        {
            Uri uri = new Uri(string.Format("{0}/RestHoliday/Save",OdataServiceUri));
            var jsonRestHoliday = JsonConvert.SerializeObject(this);
            return PostJson(uri, jsonRestHoliday, out responseMessage);
        }

        public static bool SetCanEdit(int[] idArray, bool canEdit, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri(string.Format("{0}/RestHoliday/CanEdit?canEdit={1}",OdataServiceUri,canEdit));
            var json = JsonConvert.SerializeObject(idArray);
            return PostJson(uri, json, out responseMessage);
        }

        public static bool Confirm(int[] idArray, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri(string.Format("{0}/RestHoliday/Confirm",OdataServiceUri));
            var json = JsonConvert.SerializeObject(idArray);
            return PostJson(uri, json, out responseMessage);
        }

        public static Dictionary<int, int>GetYears4Sid(string sid, bool full = false)
        {
            var uri = new Uri(string.Format("{0}/RestHoliday/GetYears4Employee?sid={1}",OdataServiceUri,sid));
            var jsonList = GetJson(uri);
            var list = JsonConvert.DeserializeObject<List<KeyValuePair<int, int>>>(jsonList);
            return list.ToDictionary(e => e.Key, e => e.Value);
        }
        
        public static DateTime GetEndDate(DateTime dateStart, int duration)
        {
            var uri = new Uri(string.Format("{0}/RestHoliday/GetEndDate?dateStart={1:yyyy-MM-dd}&duration={2}",OdataServiceUri,dateStart,duration));
            var jsonList = GetJson(uri);
            var model = JsonConvert.DeserializeObject<DateTime>(jsonList);
            return model;
        }
    }
}
