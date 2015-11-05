using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Stuff.Objects;

namespace Stuff.Models
{
    public class RestHolidayTransferDays : DbModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Descr { get; set; }

        public RestHolidayTransferDays() { }

        public static void InitList()
        {
            ResponseMessage responseMessage;
            var holiday = new RestHolidayTransferDays()
            {
                Date = new DateTime(2015, 11, 04),
                Descr = "День народного единства"
            };
            holiday.Save(out responseMessage);
            holiday = new RestHolidayTransferDays()
            {
                Date = new DateTime(2016, 01, 01),
                Descr = "Новый год"
            };
            holiday.Save(out responseMessage);
            holiday = new RestHolidayTransferDays()
            {
                Date = new DateTime(2016, 01, 07),
                Descr = "Рождество"
            };
            holiday.Save(out responseMessage);
            holiday = new RestHolidayTransferDays()
            {
                Date = new DateTime(2016, 02, 23),
                Descr = "День защитника отечества"
            };
            holiday.Save(out responseMessage);
            holiday = new RestHolidayTransferDays()
            {
                Date = new DateTime(2016, 03, 08),
                Descr = "Международный женский день"
            };
            holiday.Save(out responseMessage);
        }
        //Получение списка дней по году
        public static List<RestHolidayTransferDays> GetLists(int year)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHolidayTransferDay/GetList?year={year}");
            string jsonString = GetJson(uri);
            var model = JsonConvert.DeserializeObject<List<RestHolidayTransferDays>>(jsonString);
            return model;
        }
        //Получения списка лет
        public static int[] GetYearsList()
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHolidayTransferDay/GetYearsList");
            string jsonString = GetJson(uri);
            var model = JsonConvert.DeserializeObject<int[]>(jsonString);
            return model;
        }
        public static bool Close(int id, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHolidayTransferDay/Close?id={id}");
            string json = string.Empty;
            bool result = PostJson(uri, json, out responseMessage);
            return result;
        }
        //Добавить день
        public bool Save(out ResponseMessage responseMessage)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHolidayTransferDay/Save");
            string json = JsonConvert.SerializeObject(this);
            bool result = PostJson(uri, json, out responseMessage);
            return result;
        }
        //Копировать дни предыдущего года в текущий(year)
        public static bool CloneYear(int year, out ResponseMessage responseMessage)
        {
            Uri uri = new Uri($"{OdataServiceUri}/RestHolidayTransferDay/Clone?yearTo={year}");

            string json = string.Empty;
            bool result = PostJson(uri, json, out responseMessage);
            return result;
        }
        
        
    }
}