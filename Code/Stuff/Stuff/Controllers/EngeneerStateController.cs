using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Models;
using Stuff.Objects;

namespace Stuff.Controllers
{
    [Authorize]
    public class EngeneerStateController : BaseController
    {
        // GET: EngeneerState
        public ActionResult Index()
        {
            if (!CurUser.HasAccess(AdGroup.EngeneerStateView, AdGroup.EngeneerStateEdit)) return HttpNotFound();

            var list = EngeneerState.GetList();
            return View(list);
        }

        public ActionResult History(int id)
        {
            if (!CurUser.HasAccess(AdGroup.EngeneerStateEdit))
                return new HttpStatusCodeResult(403);
            var hislis = EngeneerState.GetHistoryList(id);
            return View(hislis);
        }

        public ActionResult GetImage(int id)
        {
            if (!CurUser.HasAccess(AdGroup.EngeneerStateView, AdGroup.EngeneerStateEdit)) return HttpNotFound();
            var vnd = new EngeneerState(id);
            byte[] imageData = vnd.Picture;
            if (imageData != null)
                return File(imageData, "image/jpeg");
            else return null;// Might need to adjust the content type based on your actual image type
        }
        [HttpPost]
        public ActionResult New(EngeneerState state)
        {
            if (!CurUser.HasAccess(AdGroup.EngeneerStateEdit)) return HttpNotFound();

            try
            {
                SaveEngeneerState(state);
                
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
                return View("New");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Image(int? id)
        {
            if (!CurUser.HasAccess(AdGroup.EngeneerStateView, AdGroup.EngeneerStateEdit)) return HttpNotFound();
            if (id.HasValue)
            {
                var vnd = new EngeneerState(id.Value);
                return View(vnd);
            }
            else
            {
                return RedirectToAction("Index", "EngeneerState");
            }

        }

        [HttpGet]
        public ActionResult New()
        {
            if (!CurUser.HasAccess(AdGroup.EngeneerStateEdit)) return HttpNotFound();

            return View();
        }
        public void Delete(int id)
        {
            if (!CurUser.HasAccess(AdGroup.EngeneerStateEdit)) return;

            try
            {
                EngeneerState.Close(id, CurUser.Sid);
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
            }
        }

        public void SaveEngeneerState(EngeneerState state)
        {
            if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                var file = Request.Files[0];
                if (file.ContentLength > 5242880)
                {
                    ViewData["error"] = "Нельзя загрузить файл размером более 5 мегабайт. Файл не был загружен.";
                    return;
                }

                string ext = Path.GetExtension(file.FileName).ToLower();

                if (ext != ".jpeg" && ext != ".jpg") throw new Exception("Формат фотографии должен быть jpeg");

                byte[] picture = null;
                using (var br = new BinaryReader(file.InputStream))
                {
                    picture = br.ReadBytes(file.ContentLength);
                }
                state.Picture = picture;
            }
            //var chkCreateAdUser = Request.Form["chkCreateAdUser"];
            //bool createAdUser = chkCreateAdUser != "false";.
            if (state.EndDate.Equals(new DateTime()))
                state.EndDate = new DateTime(3333, 3, 3);
            state.Save(CurUser.Sid);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!CurUser.HasAccess(AdGroup.EngeneerStateEdit)) return HttpNotFound();
            var user = DisplayCurUser();
            if (!user.HasAccess(AdGroup.EngeneerStateEdit))
                return new HttpStatusCodeResult(403);

            if (id.HasValue)
            {
                var vnd = new EngeneerState(id.Value);
                return View(vnd);
            }
            else
            {
                return View("New");
            }
        }
        [HttpPost]
        public ActionResult Edit(EngeneerState vnd)
        {
            if (!CurUser.HasAccess(AdGroup.EngeneerStateEdit)) return HttpNotFound();
            /*var user = DisplayCurUser();
            if (!user.UserCanEdit()) return RedirectToAction("AccessDenied", "Error");*/

            //Save employee
            try
            {
                ResponseMessage responseMessage;
                SaveEngeneerState(vnd);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Edit", vnd);
            }
            return RedirectToAction("Index");
        }
    }
}