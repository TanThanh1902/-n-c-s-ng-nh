using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Moviepro.Models;
using PagedList;
using PagedList.Mvc;

namespace Moviepro.Areas.Admin.Controllers
{
    public class TSql_CommentController : Controller
    {
        private DBMovieEntities db = new DBMovieEntities();

        // GET: Admin/TSql_Comment
        public ActionResult Index(int? page)
        {
            int num = 15;
            int pagenum = (page ?? 1);
            var tSql_Comment = db.TSql_Comment.Include(t => t.TSql_Films).Include(t => t.TSql_Informations);
            return View(tSql_Comment.OrderByDescending(t => t.DatePost).ToPagedList(pagenum, num));
        }

        // GET: Admin/TSql_Comment/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Comment tSql_Comment = await db.TSql_Comment.FindAsync(id);
            if (tSql_Comment == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Comment);
        }

        // GET: Admin/TSql_Comment/Create
        public ActionResult Create()
        {
            ViewBag.IDFilm = new SelectList(db.TSql_Films, "IDFilm", "FilmName");
            ViewBag.IDInfo = new SelectList(db.TSql_Informations, "IDInfo", "DisplayName");
            return View();
        }

        // POST: Admin/TSql_Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDComment,IDFilm,IDInfo,Comment,DatePost")] TSql_Comment tSql_Comment)
        {
            if (ModelState.IsValid)
            {
                db.TSql_Comment.Add(tSql_Comment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDFilm = new SelectList(db.TSql_Films, "IDFilm", "FilmName", tSql_Comment.IDFilm);
            ViewBag.IDInfo = new SelectList(db.TSql_Informations, "IDInfo", "DisplayName", tSql_Comment.IDInfo);
            return View(tSql_Comment);
        }

        // GET: Admin/TSql_Comment/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Comment tSql_Comment = await db.TSql_Comment.FindAsync(id);
            if (tSql_Comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDFilm = new SelectList(db.TSql_Films, "IDFilm", "FilmName", tSql_Comment.IDFilm);
            ViewBag.IDInfo = new SelectList(db.TSql_Informations, "IDInfo", "DisplayName", tSql_Comment.IDInfo);
            return View(tSql_Comment);
        }

        // POST: Admin/TSql_Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDComment,IDFilm,IDInfo,Comment,DatePost")] TSql_Comment tSql_Comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSql_Comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDFilm = new SelectList(db.TSql_Films, "IDFilm", "FilmName", tSql_Comment.IDFilm);
            ViewBag.IDInfo = new SelectList(db.TSql_Informations, "IDInfo", "DisplayName", tSql_Comment.IDInfo);
            return View(tSql_Comment);
        }

        // GET: Admin/TSql_Comment/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Comment tSql_Comment = await db.TSql_Comment.FindAsync(id);
            if (tSql_Comment == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Comment);
        }

        // POST: Admin/TSql_Comment/Delete/5
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TSql_Comment tSql_Comment = await db.TSql_Comment.FindAsync(id);
            db.TSql_Comment.Remove(tSql_Comment);
            await db.SaveChangesAsync();
            Session["countCmt"] = Int32.Parse(Session["countCmt"].ToString()) - 1;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
