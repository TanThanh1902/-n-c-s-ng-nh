using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;

namespace Moviepro.Controllers
{
    public class DetailsFilmController : Controller
    {
        DBMovieEntities db = new DBMovieEntities();
        // GET: DetailsFilm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
            }
            TSql_Films tSql_Film = db.TSql_Films.Find(id);
            foreach(var tmp in tSql_Film.TSql_Film_Category)
            {
                Session["tmpdetails"] = tmp.IDCategory;
            }
            Session["tmpFilm"] = id;
            if (tSql_Film == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Film);
        }

        public ActionResult Details_WatchFilm(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
            }
            db.TSql_Films.Find(id).Views++;
            db.SaveChanges();
            TSql_Films tSql_Film = db.TSql_Films.Find(id);
            History hs = new History();
            if(Session["History"] == null)
            {
                Session["History"] = new List<History>();
            }
            List<History> his = Session["History"] as List<History>;
            if(his.FirstOrDefault(t => t.IDFilm == id) == null)
            {
                History newItem = new History()
                {
                    IDFilm = tSql_Film.IDFilm,
                    FilmName = tSql_Film.FilmName,
                    Image = tSql_Film.Image,
                    Rating = tSql_Film.Rating,
                    Votes = tSql_Film.Votes.Value,
                    DateSubmited = tSql_Film.DateSubmited
                };
                his.Add(newItem);
            }
            if (tSql_Film == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Film);
        }
        public ActionResult Histories()
        {
            List<History> his = Session["History"] as List<History>;
            return View(his);
        }
    }
}