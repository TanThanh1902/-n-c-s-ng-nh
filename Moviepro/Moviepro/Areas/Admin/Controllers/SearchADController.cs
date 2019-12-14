using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;
using PagedList;
using PagedList.Mvc;

namespace Moviepro.Areas.Admin.Controllers
{
    public class SearchADController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Admin/SearchAD
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Search_Keyword(int? page, string key)
        {
            int num = 15;
            int pagenum = (page ?? 1);
            if(key != null)
            {
                Session["key"] = key;
            }
            string k = Session["key"].ToString();
            List<TSql_Films> tf = db.TSql_Films.Where(t => t.FilmName.Contains(k)).ToList();
            return View(tf.OrderBy(t => t.FilmName).ToPagedList(pagenum, num));
        }
    }
}