using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;

namespace Moviepro.Controllers
{
    public class RatingController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }
        // rating
        public ActionResult Rate(int? idrate, int star)
        {
            if(idrate == null)
            {
                Response.StatusCode = 404;
            }
            TSql_Films tf = db.TSql_Films.Find(idrate);
            float tmp = (float)tf.Rating;
            Int32 tmpvote = (Int32)tf.Votes;
            tf.Rating = ((tmp * tmpvote) + star) / (tmpvote + 1);
            tf.Votes++;

            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}