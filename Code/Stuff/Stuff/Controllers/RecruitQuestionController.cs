using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Models;

namespace Stuff.Controllers
{
    [Authorize]
    public class RecruitQuestionController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index(string sid)
        {
            if (String.IsNullOrEmpty(sid)) return HttpNotFound();
            try
            {
                if (!RecruitQuestionForm.CheckLink(sid)) return new HttpStatusCodeResult(404, "Ссылка устарела!");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(404, "Некорректная ссылка!");
            }
            RecruitQuestionForm.Create(sid);
            var model = new RecruitQuestionForm(sid);

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(RecruitQuestionForm model)
        {


            return View(model);
        }
    }
}