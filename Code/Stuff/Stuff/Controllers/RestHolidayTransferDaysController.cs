using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Models;
using Stuff.Objects;

namespace Stuff.Controllers
{
    public class RestHolidayTransferDaysController : BaseController
    {
        public ActionResult Index(int? year)
        {
            //RestHolidayTransferDays.InitList();
            var curYear = year ?? DateTime.Now.Year;;
            var years = RestHolidayTransferDays.GetYearsList();
            ViewBag.Years = years;
            ViewBag.CurYear = curYear;
            return View(RestHolidayTransferDays.GetLists(curYear).OrderBy(h => h.Date).ToList());
        }
        [HttpPost]
        public ActionResult Index(string newDayDate, string newDayComment)
        {
            var holiday = new RestHolidayTransferDays() {Date = DateTime.Parse(newDayDate), Descr = newDayComment};
            ResponseMessage message;
            holiday.Save(out message);
            var year = holiday.Date.Year;
            return RedirectToAction("Index", new {year});
        }

        [HttpPost]
        public bool Delete(int id)
        {
            ResponseMessage message;
            return RestHolidayTransferDays.Close(id, out message);
        }

        public bool CloneYear(int year)
        {
            ResponseMessage message;
            return RestHolidayTransferDays.CloneYear(year, out message);
        }
	}
}