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
    public class SearchController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        // Search Keyword      
        public ViewResult Search_Keyword(int? page, string txtSearch)
        {
            int num = 36;
            int pagenuber = (page ?? 1);
            if (txtSearch != null)
                Session["tmpkw"] = txtSearch.ToString();
            string sKeyword = Session["tmpkw"].ToString();
            ViewBag.Keyword = sKeyword;
            List<TSql_Films> kw = db.TSql_Films.Where(m => m.FilmName.Contains(sKeyword)).ToList();
            if (kw.Count == 0)
            {
                ViewBag.danger = "Not found";
            }
            else
            {
                ViewBag.success = "Have " + kw.Count + " result";
            }
            return View(kw.OrderBy(m => m.FilmName).ToPagedList(pagenuber, num));
        }
        // Search Country
        public ViewResult Search_Country(int? page, int? id)
        {
            int num = 36;
            int pagenum = (page ?? 1);
            TSql_Country tCountry = db.TSql_Country.SingleOrDefault(m => m.IDCountry == id);
            if (tCountry == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            List<TSql_Films> tFilm = db.TSql_Films.Where(m => m.IDCountry == id).ToList();
            if (tFilm.Count == 0)
            {
                ViewBag.danger = "Not found";
            }
            Session["country"] = tCountry.CountryName;
            ViewBag.success = "Have " + tFilm.Count + " result";
            return View(tFilm.OrderBy(m => m.FilmName).ToPagedList(pagenum, num));
        }
        // Search Category
        public ViewResult Search_Category(int? page, int? id)
        {
            int num = 36;
            int pagenum = (page ?? 1);
            TSql_Categorys tcate = db.TSql_Categorys.Find(id);
            if (tcate == null)
                Response.StatusCode = 404;
            List<TSql_Film_Category> tfc = db.TSql_Film_Category.Where(m => m.IDCategory == id).ToList();
            if (tfc.Count == 0)
                ViewBag.danger = "Not found";
            Session["Cate"] = tcate.CategoryName;
            ViewBag.success = "Have " + tfc.Count + " result";
            return View(tfc.OrderBy(m => m.TSql_Films.FilmName).ToPagedList(pagenum, num));
        }
    }
}