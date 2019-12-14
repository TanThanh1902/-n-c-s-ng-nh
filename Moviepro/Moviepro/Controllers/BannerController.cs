using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;

namespace Moviepro.Controllers
{
    public class BannerController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Banner
        public ActionResult Index()
        {
            return View();
        }
        // Banner
        public PartialViewResult Slider_Banner()
        {
            return PartialView(db.TSql_Banner.Take(7).ToList());
        }
    }
}