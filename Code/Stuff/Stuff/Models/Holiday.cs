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
    public class Holiday : DbModel
    {
        public int Id { get; set; }
        public DateTime DayDate { get; set; }
        public string Comment { get; set; }

        public Holiday() { }

        public static void InitList()
        {
            var holidayList = new List<Holiday>();
            holidayList.Add(new Holiday()
            {
                DayDate = new DateTime(2015, 11, 04),
                Comment = "День народного единства"
            });
            holidayList.Add(new Holiday()
            {
                DayDate = new DateTime(2016, 01, 01),
                Comment = "Новый год"
            });
            holidayList.Add(new Holiday()
            {
                DayDate = new DateTime(2016, 01, 07),
                Comment = "Рождество"
            });
            holidayList.Add(new Holiday()
            {
                DayDate = new DateTime(2016, 02, 23),
                Comment = "День защитника отечества"
            });
            holidayList.Add(new Holiday()
            {
                DayDate = new DateTime(2016, 03, 08),
                Comment = "Международный женский день"
            });
            var data = JsonConvert.SerializeObject(holidayList);
            TempWriteToFile(data,out data);
        }
        //Получение списка дней по году
        public static List<Holiday> GetLists(int? year)
        {
            bool success;
            var data = TempReadFromFile(out success);
            if (success)
            {
                var result =  JsonConvert.DeserializeObject<List<Holiday>>(data);
                return year == null ? result : result.FindAll(h => h.DayDate.Year == year);
            }
            return null;
        }
        //Получения списка лет
        public static int[] GetYearsList()
        {
            return new[] {2015, 2016};
        }
        public static bool DeleteHoliday(int id, out string message)
        {
            try
            {
                bool success = true;
                var data = TempReadFromFile(out success);
                if (!success)
                    throw new Exception(data);
                var list = JsonConvert.DeserializeObject<List<Holiday>>(data);
                list = list.FindAll(h => h.Id != id);
                data = JsonConvert.SerializeObject(list);
                success = TempWriteToFile(data,out data);
                if (!success)
                    throw new Exception(data);
                message = "AllRight!";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        //Добавить день
        public bool AddHoliday(out string message)
        {
            try
            {
                bool success = true;
                var data = TempReadFromFile(out success);
                if (!success)
                    throw new Exception(data);
                var list = JsonConvert.DeserializeObject<List<Holiday>>(data);
                Id = list.Count + 1;
                list.Add(this);
                data = JsonConvert.SerializeObject(list);
                success = TempWriteToFile(data, out data);
                if (!success)
                    throw new Exception(data);
                message = "AllRight!";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        //Копировать дни предыдущего года в текущий(year)
        public static bool CloneYear(out string message)
        {
            try
            {
                bool success = true;
                var prevList = GetLists(2015);
                foreach (var holiday in prevList)
                {
                    holiday.DayDate = holiday.DayDate.AddYears(1);
                    success = holiday.AddHoliday(out message);
                    if (!success)
                        throw new Exception(message);
                }
                message = "AllRight!";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        protected static bool TempWriteToFile(string data,out string responseMessage)
        {
            try
            {
                if (!Directory.Exists("D:\\Holidays"))
                    Directory.CreateDirectory("D:\\Holidays");
                if (!File.Exists("D:\\Holidays\\holiday.txt"))
                    File.Create("D:\\Holidays\\holiday.txt").Dispose();
                File.WriteAllText("D:\\Holidays\\holiday.txt", data);
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                return false;
            }
            responseMessage = "AllRight!";
            return true;
        }

        protected static string TempReadFromFile(out bool success)
        {
            try
            {
                var result = File.ReadAllText("D:\\Holidays\\holiday.txt");
                success = true;
                return result;
            }
            catch (Exception ex)
            {
                success = false;
                return ex.Message;
            }
        }
        
    }
}