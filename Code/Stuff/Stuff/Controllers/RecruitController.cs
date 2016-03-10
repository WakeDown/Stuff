﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Stuff.Helpers;
using Stuff.Models;
using Stuff.Objects;

namespace Stuff.Controllers
{
    [Authorize]
    public class RecruitController : BaseController
    {
        // GET: Recruit
        public ActionResult Index(int? topRows, int? page, string vid, string vnm,string dtdl, string pmgr ,string dtcr, string stt, int? aon, string bro, int? momy)
        {
            bool? activeOnly = null;
            if (aon.HasValue)
            {
                if (aon.Value == 1)
                {
                    activeOnly = true;
                }
                else if (aon.Value == 0)
                {
                    activeOnly = false;
                }
                else
                {
                    activeOnly = null;
                }
            }
            else
            {
                return RedirectToAction("Index", new { topRows, page, vid, vnm, dtdl, pmgr, dtcr, stt, aon = 1, bro, momy });
            }

            bool? managerOnlyMy = null;
            if (momy.HasValue)
            {
                if (momy.Value == 1)
                {
                    managerOnlyMy = true;
                }
                else if (momy.Value == 0)
                {
                    managerOnlyMy = false;
                }
                else
                {
                    managerOnlyMy = null;
                }
            }
            else
            {
                if (CurUser.Is(AdGroup.RecruitManager))
                    momy = 1;
                        else 
                    momy = -1;

                    return RedirectToAction("Index", new { topRows, page, vid, vnm, dtdl, pmgr, dtcr, stt, aon, bro, momy });
            }

            bool userIsViewer = !CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager);
            string viewerSid = null;
            if (userIsViewer) viewerSid = CurUser.Sid;

            //userIsViewer = true;
            //viewerSid = "S-1-5-21-1970802976-3466419101-4042325969-1838";
            
            int totalCount;
            int id;
            int.TryParse(vid, out id);
            string persManagerSid = CurUser.Is(AdGroup.RecruitManager) ? CurUser.Sid : null;

            var list = RecruitVacancy.GetList(out totalCount, topRows, page, id, vnm, dtdl, pmgr, dtcr, stt, activeOnly, persManagerSid, viewerSid, bro, managerOnlyMy, CurUser.Sid);
            ViewBag.TotalCount = totalCount;
            return View(list);
        }

        public PartialViewResult VacancySelection()
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            int totalCount;
            string persManagerSid = CurUser.Is(AdGroup.RecruitManager) ? CurUser.Sid : null;

            var list = RecruitVacancy.GetList(out totalCount, 1000, activeOnly:true, persManagerSid: persManagerSid);
            ViewBag.TotalCount = totalCount;
            return PartialView(list);
        }

        [HttpPost]
        public JsonResult GetVacancyList(int? topRows, int? page, string vid, string vnm, string dtdl, string pmgr, string dtcr, string stt, bool? activeOnly)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            int totalCount;
            int id;
            int.TryParse(vid, out id);
            string persManagerSid = CurUser.Is(AdGroup.RecruitManager) ? CurUser.Sid : null;
            var list = RecruitVacancy.GetList(out totalCount, topRows, page, id, vnm, dtdl, pmgr, dtcr, stt, activeOnly, persManagerSid);
            ViewBag.TotalCount = totalCount;
            return Json(new { list, totalCount });
        }

        [HttpGet]
        public ActionResult VacancyNew()
        {

            return View();
        }
        [HttpPost]
        public ActionResult VacancyNew(RecruitVacancy model)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            try
            {
                model.Create(CurUser.Sid);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("VacancyNew", model);
            }
            

            return RedirectToAction("VacancyCard",new {id=model.Id});
        }

        [HttpGet]
        public ActionResult VacancyCard(int? id)
        {
            bool userIsViewer = !CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager);
            string viewerSid = null;
            if (userIsViewer) viewerSid = CurUser.Sid;

            //userIsViewer = true;
            //viewerSid = "S-1-5-21-1970802976-3466419101-4042325969-1838";

            if (!id.HasValue) return RedirectToAction("VacancyNew");

            var model = new RecruitVacancy(id.Value, viewerSid);
            if ((CurUser.Is(AdGroup.RecruitManager) && model.PersonalManagerSid != CurUser.Sid) || (userIsViewer && model.Id <= 0))
                return HttpNotFound();
            return View(model);
        }

        [HttpPost]
        public JsonResult VacancyDelete(int id)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler)) return null;
            RecruitVacancy.Close(id, CurUser.Sid);
            return Json(new {});
        }

        public ActionResult Candidates(int? topRows, int? page, string cid, string fio, string age, string phone, string email, string added, byte? sex, string changed)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            if (!topRows.HasValue)
                topRows = 30;
            if (!page.HasValue) page = 1;
            bool? sexBool = null;
            if (sex.HasValue)
            {
                if (sex.Value == 1)
                    sexBool = true;
                else if (sex.Value == 0)
                    sexBool = false;
            }

            int totalCount;
            var list = RecruitCandidate.GetList(out totalCount, topRows, page, cid, fio, age, phone, email, added, sexBool, changed);
            ViewBag.TotalCount = totalCount;
            return View(list);
        }

       

        public PartialViewResult CandidatesSelection()
        {
            //int totalCount;
            //var list = RecruitCandidate.GetList(out totalCount, 1000000);
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetCandidateList(int? topRows, int? pageNum, string cid, string fio, string age, string phone, string email, string added, byte? sex, string changed)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
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
            var list = RecruitCandidate.GetList(out totalCount, topRows, pageNum, cid, fio, age, phone,email,added, sexBool, changed);
            return Json(new {list, totalCount});
        }

        [HttpGet]
        public ActionResult CandidateNew()
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            return View();
        }

        [HttpPost]
        public ActionResult CandidateNew(RecruitCandidate model)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            try
            {
                if (!String.IsNullOrEmpty(Request.Form["appendExistsing2Vacancy"]) &&
                    !String.IsNullOrEmpty(Request.QueryString["vid"]) &&
                    !String.IsNullOrEmpty(Request.Form["existsingId"]))
                {
                    int idVacancy;
                    int.TryParse(Request.QueryString["vid"], out idVacancy);
                    int id;
                    int.TryParse(Request.Form["existsingId"], out id);
                    if (idVacancy > 0 && id > 0) { 
                        RecruitVacancy.AppendCandidateList(idVacancy, new[] { id }, CurUser.Sid, null);
                    }
                }
                else
                {
                    model.Create(CurUser.Sid);

                    if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
                    {
                        for(int i = 0; i<Request.Files.Count;i++)
                        {
                            var file = Request.Files[i];

                            string ext = Path.GetExtension(file.FileName).ToLower();

                            //if (ext != ".png" && ext != ".jpeg" && ext != ".jpg" && ext != ".gif") throw new Exception("Формат фотографии должен быть .png .jpeg .gif");

                            byte[] data = null;
                            using (var br = new BinaryReader(file.InputStream))
                            {
                                data = br.ReadBytes(file.ContentLength);
                            }
                            RecruitCandidate.SaveFile(CurUser.Sid, model.Id, file.FileName, data);

                            //model.File = data;
                            //model.FileName = file.FileName; 
                        }

                    }
                    

                    if (!String.IsNullOrEmpty(Request.Form["append2Vacancy"]) &&
                        !String.IsNullOrEmpty(Request.QueryString["vid"]))
                    {
                        int idVacancy;
                        int.TryParse(Request.QueryString["vid"], out idVacancy);
                        if (idVacancy > 0 && model.Id > 0)
                        {
                            RecruitVacancy.AppendCandidateList(idVacancy, new[] {model.Id}, CurUser.Sid, model.IdCameType);
                        }
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
            if (!CurUser.HasAccess(AdGroup.RecruitControler)) return null;
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
        public JsonResult ChangeVacancy(int id, string personalManagerSid, string comment)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler,AdGroup.RecruitManager)) return null;
            RecruitVacancy.Change(CurUser.Sid, id, personalManagerSid, comment);

            return Json(new {});
        }

        [HttpPost]
        public JsonResult GetVacancyHistory(int id, bool full=false)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            int totalCount;
           var list = RecruitVacancy.GetHistory(out totalCount, id, full);
            return Json(new { list, totalCount});
        }

        [HttpPost]
        public JsonResult GetCandidateHistory(int id, bool full = false)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            int totalCount;
            var list = RecruitCandidate.GetHistory(out totalCount, id, full);
            return Json(new { list, totalCount });
        }

        [HttpPost]
        public JsonResult GetVacancyCandadateList(int id)
        {
            bool userIsViewer = !CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager);
            string viewerSid = null;
            if (userIsViewer) viewerSid = CurUser.Sid;

            //userIsViewer = true;
            //viewerSid = "S-1-5-21-1970802976-3466419101-4042325969-1838";

            int totalCount;
            var list = RecruitVacancy.GetCandidateList(out totalCount, id, viewerSid);
            
            return Json(new { list, totalCount });
        }

        [HttpPost]
        public JsonResult GetCandadateVacancyList(int id)
        {
            bool userIsViewer = !CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager);
            string viewerSid = null;
            if (userIsViewer) viewerSid = CurUser.Sid;
            int totalCount;
            var list = RecruitCandidate.GetVacancyList(out totalCount, id, viewerSid:viewerSid);
            return Json(new { list, totalCount });
        }

        [HttpPost]
        public JsonResult AppendCandidates2Vacancy(int idVacancy, int[] idCandidates)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            RecruitVacancy.AppendCandidateList(idVacancy, idCandidates, CurUser.Sid, null);

            return Json(new { });
        }

        [HttpPost]
        public JsonResult ChangeVacancy4Candidate(int idSelection, int[] idVacancies)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            RecruitSelection.ChangeVacancy(idSelection, idVacancies, CurUser.Sid);

            return Json(new {});
        }
        

            [HttpPost]
        public JsonResult SelectionSetCancelState(int id, string descr)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            RecruitSelection.SetState(id, "CANCEL", CurUser.Sid, descr);
            var sel = new RecruitSelection(id);
            return Json(sel);
        }

        [HttpPost]
        public JsonResult SelectionRestore(int id, string descr=null)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            RecruitSelection.Restore(id, CurUser.Sid, descr);
            var sel = new RecruitSelection(id);
            return Json(sel);
        }

        [HttpPost]
        public JsonResult SelectionSetAcceptState(int id, string descr)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            RecruitSelection.SetState(id, "SECCHIEFACCEPT", CurUser.Sid, descr);
            var sel = new RecruitSelection(id);
            return Json(sel);
        }

        [HttpPost]
        public JsonResult SelectionSetNextState(int id, int idState, string descr)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            RecruitSelection.SetState(id, idState, CurUser.Sid, descr);
            var sel = new RecruitSelection(id);
            return Json(sel);
        }

        [HttpPost]
        public JsonResult SelectionSetChiefAcceptState(int id, string descr)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            RecruitSelection.SetState(id, "SECCHIEFACCEPT", CurUser.Sid, descr);
            var sel = new RecruitSelection(id);
            return Json(sel);
        }

        public PartialViewResult SelectionHistory(int? id)
        {
            bool userIsViewer = !CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager);
            string viewerSid = null;
            if (userIsViewer) viewerSid = CurUser.Sid;

            //userIsViewer = true;
            //viewerSid = "S-1-5-21-1970802976-3466419101-4042325969-1838";
            if (!id.HasValue) return null;

            var list = RecruitSelection.GetHistory(id.Value, viewerSid);

            return PartialView(list);
        }

        public PartialViewResult SelectionTinyHistory(int? id)
        {
            bool userIsViewer = !CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager);
            string viewerSid = null;
            if (userIsViewer) viewerSid = CurUser.Sid;

            //userIsViewer = true;
            //viewerSid = "S-1-5-21-1970802976-3466419101-4042325969-1838";
            if (!id.HasValue) return null;

            var list = RecruitSelection.GetHistory(id.Value, viewerSid);

            return PartialView(list);
        }

        [HttpPost]
        public JsonResult GetVacancyStateList()
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            var list = RecruitVacancy.GetStateList();
            return Json(list);
        }

        [HttpPost]
        public JsonResult GetTopSelection(int slid)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            var selection = new RecruitSelection(slid);
            return Json(selection);
        }

        [HttpGet]
        public FileResult GetCandidateFile(string sid)
        {
            //if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            string fileName;
            var data = RecruitCandidate.GetFileData(sid, out fileName);
            if (data != null && data.Length > 0)
            {
                var mimeType = MimeTypeHelper.GetMimeType(Path.GetExtension(fileName));
                return File(data, mimeType, fileName);
                //return File(data, "application/pdf");
            }
            else
            {
                return null;
                //return HttpNotFound();
            }
        }

        [HttpPost]
        public JsonResult DeleteFile(string sid)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            RecruitCandidate.DeleteFile(sid, CurUser.Sid);
            return null;
        }

        [HttpPost]
        public JsonResult GetCandidateFileList(int id)
        {
            var list = RecruitCandidate.GetFiles(id);
            return Json(list);
        }

        [HttpPost]
        public ActionResult CandidateChange(RecruitCandidate model)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            try
            {
                model.Change(CurUser.Sid);

                if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];

                        string ext = Path.GetExtension(file.FileName).ToLower();

                        //if (ext != ".png" && ext != ".jpeg" && ext != ".jpg" && ext != ".gif") throw new Exception("Формат фотографии должен быть .png .jpeg .gif");

                        byte[] data = null;
                        using (var br = new BinaryReader(file.InputStream))
                        {
                            data = br.ReadBytes(file.ContentLength);
                        }
                        RecruitCandidate.SaveFile(CurUser.Sid, model.Id, file.FileName, data);

                        //model.File = data;
                        //model.FileName = file.FileName; 
                    }

                }


                //if (!String.IsNullOrEmpty(Request.Form["append2Vacancy"]) && !String.IsNullOrEmpty(Request.QueryString["vid"]))
                //{
                //    int idVacancy;
                //    int.TryParse(Request.QueryString["vid"], out idVacancy);
                //    if (idVacancy > 0 && model.Id > 0)
                //    {
                //        RecruitVacancy.AppendCandidateList(idVacancy, new[] { model.Id }, CurUser.Sid);
                //    }
                //}
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("CandidateCard", model);
            }

            return RedirectToAction("CandidateCard", new {id= model.Id});
        }

        [HttpPost]
        public JsonResult GetEmployeeListSid()
        {
            var list = Employee.GetList();
            return Json(list);
        }

        [HttpPost]
        public JsonResult GetPersonalManagerListSid()
        {
            var list = AdHelper.GetUserListByAdGroup(AdGroup.RecruitManager, AdGroup.RecruitControler);
            return Json(list);
        }

        [HttpPost]
        public JsonResult GetPositionList()
        {
            var list = Position.GetList();
            return Json(list);
        }

        [HttpPost]
        public JsonResult GetDepartmentList()
        {
            var list = Department.GetList();
            return Json(list);
        }

        [HttpPost]
        public JsonResult CheckCandidateClone(string surname, string name, string patronymic)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitControler, AdGroup.RecruitManager)) return null;
            int id = RecruitCandidate.CheckClone(surname, name, patronymic);
            return Json(id);
        }

        [HttpPost]
        public JsonResult CreateQuestionLink(int idSelection)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitManager, AdGroup.RecruitControler)) return null;

            string sid = RecruitQuestionForm.CreateLink(CurUser.Sid, idSelection);
            return Json(new {sid});
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult SendCameMail(string subj, string text, string mail)
        {
            if (!CurUser.HasAccess(AdGroup.RecruitManager, AdGroup.RecruitControler)) return null;
            try
            {
                MessageHelper.SendMailSmtp(subj, text, true, mail);
            }
            catch (Exception ex)
            {
                return Json(new {error=ex.Message });
            }
            return Json(new { });
        }
    }
}