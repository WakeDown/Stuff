using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Models;
using Stuff.Objects;

namespace Stuff.Controllers
{
    public class RecruitController : BaseController
    {
        // GET: Recruit
        public ActionResult Index()
        {
            int totalCount;
            var list = RecruitVacancy.GetList(out totalCount);
            return View(list);
        }
        [HttpGet]
        public ActionResult VacancyNew()
        {

            return View();
        }
        [HttpPost]
        public ActionResult VacancyNew(RecruitVacancy model)
        {
            try
            {
                model.Create(CurUser.Sid);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("VacancyNew", model);
            }
            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult VacancyCard(int? id)
        {
            if (!id.HasValue) return RedirectToAction("VacancyNew");

            var model = new RecruitVacancy(id.Value);
            return View(model);
        }

        [HttpPost]
        public JsonResult VacancyDelete(int id)
        {
            RecruitVacancy.Close(id, CurUser.Sid);
            return Json(new {});
        }

        public ActionResult Candidates()
        {
            int totalCount;
            var list = RecruitCandidate.GetList(out totalCount);
            return View(list);
        }
        [HttpGet]
        public ActionResult CandidateNew()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CandidateNew(RecruitCandidate model)
        {
            try
            {
                model.Create(CurUser.Sid);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("CandidateNew", model);
            }


            return RedirectToAction("Candidates");
        }

        [HttpPost]
        public JsonResult CandidateDelete(int id)
        {
            RecruitCandidate.Close(id, CurUser.Sid);
            return Json(new { });
        }

        [HttpGet]
        public ActionResult CandidateCard(int? id)
        {
            if (!id.HasValue) return RedirectToAction("CandidateNew");

            var model = new RecruitCandidate(id.Value);
            return View(model);
        }
    }
}