using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;

namespace Moviepro.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List_Category()
        {
            return View();
        }
        public PartialViewResult Menu()
        {
            return PartialView();
        }
        public PartialViewResult TemplateMenu()
        {
            return PartialView();
        }
    }
}