using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Helpers;
using Stuff.Models;
using Stuff.Objects;

namespace Stuff.Controllers
{
    public class DepartmentController : BaseController
    {
        public ActionResult List()
        {
            var user = DisplayCurUser();
            if (!user.UserCanEdit()) return RedirectToAction("AccessDenied", "Error");
            var deps = Department.GetList().ToArray();

            return View(deps);
        }

        public ActionResult Employees()
        {
            DisplayCurUser();
            var list = Department.GetList().ToArray();

            return View(list);
        }
        public ActionResult EmployeesTable(int departmentId, bool userCanEdit)
        {
            var employeeList = Employee.GetList(idDepartment: departmentId);
            ViewBag.UserCanEdit = userCanEdit;
            return PartialView(employeeList);
        }

        public ActionResult EmployeesRestHolidays(int? year)
        {
            DisplayCurUser();
            var curYear = (year ?? DateTime.Now.Year) <= 2015 ? 2016 : year ?? DateTime.Now.Year;
            ViewBag.CurYear = curYear;
            ViewBag.Years = RestHoliday.GetYears4Sid(null).Select(y => y.Key).ToArray();
            var list = Department.GetList().ToArray();
            return View(list);
        }

        public ActionResult EmployeesRestHolidaysTable(int departmentId, int curYear)
        {
            var employeeList = Employee.GetList(idDepartment : departmentId);
            ViewBag.CurYear = curYear;
            return PartialView(employeeList);
        }
        public ActionResult Index()
        {
            DisplayCurUser();

            var list = Department.GetOrgStructure().ToList();

            return View(list);
        }

        [HttpGet]
        public ActionResult New()
        {
            var user = DisplayCurUser();
            if (!user.UserCanEdit()) return RedirectToAction("AccessDenied", "Error");

            return View();
        }
        [HttpPost]
        public ActionResult New(Department model)
        {
            var user = DisplayCurUser();
            if (!user.UserCanEdit()) return RedirectToAction("AccessDenied", "Error");

            //Save department
            try
            {
                ResponseMessage responseMessage;
                //dep.Creator = new Employee(){AdSid = GetCurUser().Sid};
                bool complete = model.Save(out responseMessage);
                if (!complete) throw new Exception(responseMessage.ErrorMessage);

                return RedirectToAction("Edit", "Department", new { id = responseMessage.Id });
            }
            catch (Exception ex)
            {
                ViewData["ServerError"] = ex.Message;
                return View("New", model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var user = DisplayCurUser();
            if (!user.UserCanEdit()) return RedirectToAction("AccessDenied", "Error");

            if (id.HasValue)
            {
                var dep = new Department(id.Value);
                return View(dep);
            }
            else
            {
                return View("New");
            }
        }
        [HttpPost]
        public ActionResult Edit(Department dep)
        {
            var user = DisplayCurUser();
            if (!user.UserCanEdit()) return RedirectToAction("AccessDenied", "Error");

            try
            {
                ResponseMessage responseMessage;
                bool complete = dep.Save(out responseMessage);
                if (!complete) throw new Exception(responseMessage.ErrorMessage);

                return RedirectToAction("Edit", "Department", new { id = responseMessage.Id });
            }
            catch (Exception ex)
            {
                ViewData["ServerError"] = ex.Message;
                return RedirectToAction("Edit", "Department", new { id = dep.Id });
            }
        }

        [HttpPost]
        public void Delete(int id)
        {
            var user = DisplayCurUser();
            if (!user.UserCanEdit()) RedirectToAction("AccessDenied", "Error");
            try
            {
                ResponseMessage responseMessage;
                bool complete = Department.Delete(id, out responseMessage);
                if (!complete) throw new Exception(responseMessage.ErrorMessage);
            }
            catch (Exception ex)
            {
                ViewData["ServerError"] = ex.Message;
            }
        }

        [HttpPost]
        public JsonResult GetStuff(int? idDepartment)
        {
            try
            {
                var list = Employee.GetList(idDepartment: idDepartment);
                return Json(list);
            }
            catch (Exception ex)
            {
                ViewData["ServerError"] = ex.Message;
                return Json(new { errorMessage = ex.Message });
            }
        }
        
	}
}