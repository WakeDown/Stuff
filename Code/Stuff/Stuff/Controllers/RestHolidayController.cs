using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Mvc;
using System.Web.WebSockets;
using Newtonsoft.Json;
using Stuff.Models;
using Stuff.Objects;

namespace Stuff.Controllers
{
    public class RestHolidayController : BaseController
    {
        public ActionResult Index(int? year, bool?success, string message)
        {
            var sid = CurUser.Sid;
            year = year ?? DateTime.Now.Year;
            if (year <= 2015) year = 2016;
            var restHolidays = RestHoliday.GetRestHolidaysForYear(sid, (int)year);
            TempData["success"] = success ?? false;
            TempData["message"] = message ?? "";
            TempData["curYear"] = year;
            var years = RestHoliday.GetYears4Sid(sid);
            TempData["years"] = years;
            TempData["startDate"] = year == DateTime.Now.Year 
                ? DateTime.Now.ToShortDateString()
                : new DateTime((int)year, 1, 1).ToShortDateString();
            TempData["endDate"] = new DateTime((int)year,12,31).ToShortDateString();
            TempData["userCanAdd"] = years[(int)year]>0 && year >= DateTime.Now.Year;
            return View(restHolidays);
        }
        public string DeleteRestHoliday(int year, string id)
        {
            ResponseMessage responseMessage;
            RestHoliday.Delete(int.Parse(id), out responseMessage);
            return responseMessage?.ErrorMessage ?? "";
        }

        public ActionResult List(int? year, string message)
        {
            TempData["message"] = message ?? "";
            year = year ?? DateTime.Now.Year;
            if (year <= 2015) year = 2016;
            ViewBag.Years = RestHoliday.GetYears4Sid(null).Select(y =>y.Key).ToArray();
            ViewBag.CurYear = year;
            ViewBag.CurUser = GetCurUser();
            return View(EmployeeRestHoliday.GetEmployeeList(year.Value));
        }
        public string SaveRestHoliday(string startDate, string duration)
        {
            try
            {
                var sid = CurUser.Sid;
                var restHoliday = new RestHoliday(DateTime.Parse(startDate), Byte.Parse(duration), sid);
                ResponseMessage responseMessage;

                return restHoliday.Save(out responseMessage)
                    ? "Отпуск добавлен"
                    : responseMessage.ErrorMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ActionResult SetCanEditForYearTrue(int year, string sid)
        {
            ResponseMessage responseMessage;
            EmployeeRestHoliday.CanEdit(sid, year, true, out responseMessage);
            var message = responseMessage?.ErrorMessage;
            return RedirectToAction("List", "RestHoliday", new {year, message});
        }
        public ActionResult SetCanEditForYearFalse(int year, string str)
        {
            var idArray = Array.ConvertAll(str.Trim(',').Split(','), s => int.Parse(s)) ;
            ResponseMessage responseMessage;
            var success = RestHoliday.SetCanEdit(idArray, false, out responseMessage);
            return RedirectToAction("Index", new {year, success, message = responseMessage?.ErrorMessage ?? "Отпуска сохранены." });
        }
    }
}