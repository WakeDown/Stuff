using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Models;
using Stuff.Objects;

namespace Stuff.Controllers
{
    public class HolidaysController : BaseController
    {
        public ActionResult Index(int? year)
        {
            //Holiday.InitList();
            var curYear = year ?? DateTime.Now.Year;;
            var years = Holiday.GetYearsList();
            ViewBag.Years = years;
            ViewBag.CurYear = curYear;
            return View(Holiday.GetLists(curYear).OrderBy(h => h.DayDate).ToList());
        }
        [HttpPost]
        public ActionResult Index(string newDayDate, string newDayComment)
        {
            var holiday = new Holiday() {DayDate = DateTime.Parse(newDayDate), Comment = newDayComment};
            string message;
            holiday.AddHoliday(out message);
            var year = holiday.DayDate.Year;
            return RedirectToAction("Index", new {year});
        }

        [HttpPost]
        public bool Delete(int id)
        {
            string message;
            return Holiday.DeleteHoliday(id, out message);
        }

        public bool CloneYear()
        {
            string message;
            return Holiday.CloneYear(out message);
        }
	}
}