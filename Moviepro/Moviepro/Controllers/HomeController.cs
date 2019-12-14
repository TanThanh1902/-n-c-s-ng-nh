using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;

namespace Moviepro.Controllers
{
    public class HomeController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Home
        public ActionResult Index()
        {
            Session["tmpdetails"] = 0;
            List<TSql_Informations> info = db.TSql_Informations.Where(t => t.Role != 1).ToList();
            Session["countUser"] = info.Count;
            List<TSql_Films> tf = db.TSql_Films.ToList();
            Session["countFilm"] = tf.Count;
            List<TSql_Chat> chat = db.TSql_Chat.ToList();
            Session["countChat"] = chat.Count;
            List<TSql_Comment> cmt = db.TSql_Comment.ToList();
            Session["countCmt"] = cmt.Count;
            return View();
        }
        // CheckSession Info
        public PartialViewResult CheckSession()
        {
            return PartialView();
        }
        // Account
        public PartialViewResult Account()
        {
            return PartialView();
        }
        // Tool
        public PartialViewResult Tool()
        {
            return PartialView();
        }
    }
}