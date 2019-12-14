using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moviepro.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public PartialViewResult Home()
        {
            return PartialView();
        }
        public PartialViewResult CommingSoon()
        {
            return PartialView();
        }
        public PartialViewResult History()
        {
            return PartialView();
        }
        public PartialViewResult az()
        {
            return PartialView();
        }
        public PartialViewResult No()
        {
            return PartialView();
        }
    }
}