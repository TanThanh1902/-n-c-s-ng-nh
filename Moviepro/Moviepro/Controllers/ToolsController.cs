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
    public class ToolsController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Tools
        public ActionResult Index()
        {
            return View();
        }
        // Category
        public PartialViewResult menu_Category()
        {
            return PartialView(db.TSql_Categorys.ToList());
        }
        // Country
        public PartialViewResult menu_Country()
        {
            return PartialView(db.TSql_Country.ToList());
        }
        // All film a-z
        public ActionResult menu_All(int? page)
        {
            int num = 42;
            int pagenumber = (page ?? 1);
            return View(db.TSql_Films.Where(t => t.LinkFilm != null).OrderBy(m => m.FilmName).ToPagedList(pagenumber, num));
        }
        public ActionResult menu_Year()
        {
            return PartialView();
        }
    }
}