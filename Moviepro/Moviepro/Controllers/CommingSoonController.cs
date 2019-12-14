using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;
using PagedList;
using PagedList.Mvc;

namespace Moviepro.Controllers
{
    public class CommingSoonController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: CommingSoon
        public ActionResult Comming_Soon(int? page)
        {
            int num = 36;
            int pagenum = (page ?? 1);
            List<TSql_Films> tf = db.TSql_Films.Where(t => t.LinkFilm == null).ToList();
            if(tf.Count == 0)
            {
                ViewBag.Comming = "Not found";
            }
            return View(tf.OrderBy(t => t.FilmName).ToPagedList(pagenum, num));
        }
    }
}