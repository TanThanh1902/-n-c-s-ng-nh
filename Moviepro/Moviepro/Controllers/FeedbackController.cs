using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;

namespace Moviepro.Controllers
{
    public class FeedbackController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(TSql_Chat fb)
        {
            if(ModelState.IsValid)
            {
                TSql_Informations info = (TSql_Informations)Session["flag"];
                fb.IDUser = info.IDInfo;
                fb.DateChat = DateTime.Now;
                db.TSql_Chat.Add(fb);
                db.SaveChanges();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}