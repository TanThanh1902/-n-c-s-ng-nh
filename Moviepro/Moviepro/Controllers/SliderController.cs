using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;

namespace Moviepro.Controllers
{
    public class SliderController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Slider
        public ActionResult Index()
        {
            return View();
        }
        // Film New
        public PartialViewResult Slider_New()
        {
            return PartialView(db.TSql_Films.Take(7).ToList());
        }
    }
}