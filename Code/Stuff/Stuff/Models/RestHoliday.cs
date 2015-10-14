﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;

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
            Uri uri = new Uri($"{OdataServiceUri}/RestHoliday/GetList?employeeSid={employeeSid}&year={year}");
            var jsonList = GetJson(uri);
            return JsonConvert.DeserializeObject<List<RestHoliday>>(jsonList);
        }

        public static bool Delete(int id, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHoliday/Close?id={id}");
            return PostJson(uri, string.Empty, out responseMessage);
        }

        public bool Save(out ResponseMessage responseMessage)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHoliday/Save");
            var jsonRestHoliday = JsonConvert.SerializeObject(this);
            return PostJson(uri, jsonRestHoliday, out responseMessage);
        }

        public static bool SetCanEdit(int[] idArray, bool canEdit, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHoliday/CanEdit?canEdit={canEdit}");
            var json = JsonConvert.SerializeObject(idArray);
            return PostJson(uri, json, out responseMessage);
        }

        public static bool Confirm(int[] idArray, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHoliday/Confirm");
            var json = JsonConvert.SerializeObject(idArray);
            return PostJson(uri, json, out responseMessage);
        }

        public static Dictionary<int, int>GetYears4Sid(string sid)
        {
            var uri = new Uri($"{OdataServiceUri}/RestHoliday/GetYears4Employee?sid={sid}");
            var jsonList = GetJson(uri);
            var list = JsonConvert.DeserializeObject<List<KeyValuePair<int, int>>>(jsonList);
            return list.ToDictionary(e => e.Key, e => e.Value);
        }

    }
}
