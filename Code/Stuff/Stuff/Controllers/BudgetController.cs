using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Models;
using Stuff.Objects;

namespace Stuff.Controllers
{
    [Authorize]
    public class BudgetController : BaseController
    {
        public ActionResult Index()
        {
            if (!CurUser.HasAccess(AdGroup.PersonalManager)) return RedirectToAction("AccessDenied", "Error");
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(Budget model)
        //{
        //    if (!CurUser.HasAccess(AdGroup.PersonalManager)) return RedirectToAction("AccessDenied", "Error");

        //    try
        //    {
        //        ResponseMessage responseMessage;
        //        bool complete = model.Save(out responseMessage);
        //        if (!complete) throw new Exception(responseMessage.ErrorMessage);
        //        TempData["ServerSuccess"] = "Бюджет успешно добавлен";
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ServerError"] = ex.Message;
        //        return View("Index", model);
        //    }
        //}

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!CurUser.HasAccess(AdGroup.PersonalManager)) return null;
            try
            {
                ResponseMessage responseMessage;
                bool complete = Budget.Delete(id, out responseMessage);
                if (!complete) throw new Exception(responseMessage.ErrorMessage);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return null;
        }

        [HttpGet]
        public ActionResult New()
        {
            if (!CurUser.UserCanEdit()) return RedirectToAction("AccessDenied", "Error");
            return View();
        }
        [HttpPost]
        public ActionResult New(Budget model)
        {
            if (!CurUser.HasAccess(AdGroup.PersonalManager)) return RedirectToAction("AccessDenied", "Error");

            try
            {
                ResponseMessage responseMessage;
                bool complete = model.Save(out responseMessage);
                if (!complete) throw new Exception(responseMessage.ErrorMessage);

                return RedirectToAction("Index", new { id = responseMessage.Id });
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
            if (!user.HasAccess(AdGroup.PersonalManager)) return RedirectToAction("AccessDenied", "Error");

            if (id.HasValue)
            {
                var dep = new Budget(id.Value);
                return View(dep);
            }
            else
            {
                return View("New");
            }
        }
        [HttpPost]
        public ActionResult Edit(Budget model)
        {
            if (!CurUser.HasAccess(AdGroup.PersonalManager)) return RedirectToAction("AccessDenied", "Error");

            try
            {
                ResponseMessage responseMessage;
                bool complete = model.Save(out responseMessage);
                if (!complete) throw new Exception(responseMessage.ErrorMessage);

                return RedirectToAction("Index", new { id = responseMessage.Id });
            }
            catch (Exception ex)
            {
                ViewData["ServerError"] = ex.Message;
                return RedirectToAction("Edit", new { id = model.Id });
            }
        }
    }
}