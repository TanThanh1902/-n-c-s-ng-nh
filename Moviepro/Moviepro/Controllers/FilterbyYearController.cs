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
    public class FilterbyYearController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: FilterbyYear
        public ActionResult Year(int? page, int year)
        {
            ViewBag.Year = year.ToString();
            int num = 36;
            int pagenum = (page ?? 1);
            List<TSql_Films> tf = db.TSql_Films.Where(t => t.DateSubmited.Value.Year == year).ToList();
            if(tf.Count == 0)
            {
                ViewBag.TBYear = "Not Found";
            }
            return View(tf.OrderByDescending(t => t.DateSubmited).ToPagedList(pagenum, num));
        }
    }
}