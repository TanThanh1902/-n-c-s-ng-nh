using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;
using PagedList;
using PagedList.Mvc;

namespace Moviepro.Controllers
{
    public class CommentsController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Comments
        public ActionResult Index(int? page, int? id)
        {
            Session["phim"] = id;
            int num = 10;
            int pagenum = (page ?? 1);
            var comments = db.TSql_Comment.Where(t => t.IDFilm == id).Include(t => t.TSql_Reply).OrderByDescending(t => t.DatePost).ToList();
            return View(comments.ToPagedList(pagenum, num));
        }
        public ActionResult Index_W(int? page, int? id)
        {
            int num = 10;
            int pagenum = (page ?? 1);
            var comments = db.TSql_Comment.Where(t => t.IDFilm == id).Include(t => t.TSql_Reply).OrderByDescending(t => t.DatePost).ToList();
            return View(comments.ToPagedList(pagenum, num));
        }
        // Create new Comment
        [HttpPost]
        public ActionResult PostComment(TSql_Comment cmt)
        {
            TSql_Informations info = (TSql_Informations)Session["flag"];
            cmt.IDInfo = info.IDInfo;
            cmt.DatePost = DateTime.Now;
            cmt.IDFilm = Int32.Parse(Session["tmpFilm"].ToString());
            db.TSql_Comment.Add(cmt);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        // Create new Reply
        [HttpPost]
        public ActionResult PostReply(TSql_Reply rep, int idcmt)
        {
            TSql_Informations info = (TSql_Informations)Session["flag"];
            rep.IDInfo = info.IDInfo;
            rep.IDComment = idcmt;
            rep.DatePost = DateTime.Now;
            db.TSql_Reply.Add(rep);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}