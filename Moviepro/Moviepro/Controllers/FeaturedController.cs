using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;

namespace Moviepro.Controllers
{
    public class FeaturedController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Featured
        public ActionResult Index()
        {
            return PartialView();
        }
        public PartialViewResult menu_Feature()
        {
            return PartialView(db.TSql_Films.Take(24).ToList());
        }
        public PartialViewResult menu_Views()
        {
            return PartialView(db.TSql_Films.OrderByDescending(m => m.Views).Take(24).ToList());
        }
        public PartialViewResult menu_Rating()
        {
            return PartialView(db.TSql_Films.OrderByDescending(m => m.Rating).Take(24).ToList());
        }
        public PartialViewResult menu_Recently_Added()
        {
            return PartialView(db.TSql_Films.OrderByDescending(m => m.DateSubmited).Take(24).ToList());
        }
    }
}