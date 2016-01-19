using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff.Models;

namespace Stuff.Controllers
{
    [AllowAnonymous]
    public class RecruitQuestionController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string sid)
        {
            if (String.IsNullOrEmpty(sid)) return HttpNotFound();
            if (!RecruitQuestionForm.CheckLink(sid)) return new HttpStatusCodeResult(404, "Ссылка устарела!");
            RecruitQuestionForm.Create(sid);
            var model = new RecruitQuestionForm(sid);

            return View(model);
        }
    }
}