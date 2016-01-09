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
    public class RecruitController : BaseController
    {
        // GET: Recruit
        public ActionResult Index(int? topRows, int? page, string vid, string vnm,string dtdl, string pmgr ,string dtcr, string stt)
        {
            int totalCount;
            int id;
            int.TryParse(vid, out id);
            var list = RecruitVacancy.GetList(out totalCount, topRows, page, id, vnm, dtdl, pmgr, dtcr, stt);
            ViewBag.TotalCount = totalCount;
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

        public PartialViewResult CandidatesSelection()
        {
            //int totalCount;
            //var list = RecruitCandidate.GetList(out totalCount, 1000000);
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetCandidateList(int? topRows, int? pageNum, string cid, string fio, string age, string phone, string email, string added, byte? sex)
        {
            if (!topRows.HasValue)
                topRows = 10;
            if (!pageNum.HasValue) pageNum = 1;
            bool? sexBool = null;
            if (sex.HasValue)
            {
                if (sex.Value == 1)
                    sexBool = true;
                else if (sex.Value == 0)
                    sexBool = false;
            }

            int totalCount;
            var list = RecruitCandidate.GetList(out totalCount, topRows, pageNum, cid, fio, age, phone,email,added, sexBool);
            return Json(new {list, totalCount});
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

                if (!String.IsNullOrEmpty(Request.Form["append2Vacancy"]) && !String.IsNullOrEmpty(Request.QueryString["vid"]))
                {
                    int idVacancy;
                    int.TryParse(Request.QueryString["vid"], out idVacancy);
                    if (idVacancy > 0 && model.Id > 0)
                    {
                        RecruitVacancy.AppendCandidateList(idVacancy, new []{model.Id}, CurUser.Sid);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("CandidateNew", model);
            }

            if (String.IsNullOrEmpty(Request.QueryString["returnUrl"]))
            {
                return RedirectToAction("Candidates");
            }
            else
            {
                return Redirect(Request.QueryString["returnUrl"]);
            }
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
        [HttpPost]
        public JsonResult GetPersonalManagerList()
        {
            var list = AdHelper.GetUserListByAdGroup(AdGroup.PersonalManager);
            return Json(list);
        }

        [HttpPost]
        public JsonResult ChangeVacancy(int id, string personalManagerSid)
        {
            RecruitVacancy.Change(CurUser.Sid, id, personalManagerSid);

            return Json(new {});
        }

        [HttpPost]
        public JsonResult GetVacancyHistory(int id, bool full=false)
        {
            int totalCount;
           var list = RecruitVacancy.GetHistory(out totalCount, id, full);
            return Json(new { list, totalCount});
        }

        [HttpPost]
        public JsonResult GetVacancyCandadateList(int id)
        {
            int totalCount;
            var list = RecruitVacancy.GetCandidateList(out totalCount, id);
            return Json(new { list, totalCount });
        }
        [HttpPost]
        public JsonResult AppendCandidates2Vacancy(int idVacancy, int[] idCandidates)
        {
            RecruitVacancy.AppendCandidateList(idVacancy, idCandidates, CurUser.Sid);

            return Json(new {});
        }
        

            [HttpPost]
        public JsonResult SelectionSetCancelState(int id, string descr)
        {
            RecruitSelection.SetState(id, "CANCEL", CurUser.Sid, descr);
            var sel = new RecruitSelection(id);
            return Json(sel);
        }

        [HttpPost]
        public JsonResult SelectionSetAcceptState(int id, string descr)
        {
            RecruitSelection.SetState(id, "SECCHIEFACCEPT", CurUser.Sid, descr);
            var sel = new RecruitSelection(id);
            return Json(sel);
        }

        [HttpPost]
        public JsonResult SelectionSetNextState(int id, int idState, string descr)
        {
            RecruitSelection.SetState(id, idState, CurUser.Sid, descr);
            var sel = new RecruitSelection(id);
            return Json(sel);
        }

        public PartialViewResult SelectionHistory(int? id)
        {
            if (!id.HasValue) return null;

            var list = RecruitSelection.GetHistory(id.Value);

            return PartialView(list);
        }

        [HttpPost]
        public JsonResult GetVacancyStateList()
        {
            var list = RecruitVacancy.GetStateList();
            return Json(list);
        }
    }
}