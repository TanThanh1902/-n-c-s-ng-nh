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
using System.IO;

namespace Moviepro.Areas.Admin.Controllers
{
    public class TSql_BannerController : Controller
    {
        private DBMovieEntities db = new DBMovieEntities();

        // GET: Admin/TSql_Banner
        public async Task<ActionResult> Index()
        {
            return View(await db.TSql_Banner.ToListAsync());
        }

        // GET: Admin/TSql_Banner/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Banner tSql_Banner = await db.TSql_Banner.FindAsync(id);
            if (tSql_Banner == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Banner);
        }

        // GET: Admin/TSql_Banner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TSql_Banner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDBanner,Banner,FilmName,Description")] TSql_Banner tSql_Banner, HttpPostedFileBase fileimg)

        {
            if (ModelState.IsValid)
            {
                db.TSql_Banner.Add(tSql_Banner);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tSql_Banner);
        }

        // GET: Admin/TSql_Banner/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Banner tSql_Banner = await db.TSql_Banner.FindAsync(id);
            if (tSql_Banner == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Banner);
        }

        // POST: Admin/TSql_Banner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDBanner,Banner,FilmName,Description")] TSql_Banner tSql_Banner, HttpPostedFileBase fileimg)
        {
            if (ModelState.IsValid)
            {
                var img = Path.GetFileName(fileimg.FileName);
                var pathimg = Path.Combine(Server.MapPath("~/Content/images"), img);
                if (fileimg == null)
                {
                    ViewBag.Img = "Chose images";
                    return View();
                }
                else if (System.IO.File.Exists(pathimg))
                    ViewBag.Img = "Images had exists";
                else
                    fileimg.SaveAs(pathimg);
                tSql_Banner.Banner = fileimg.FileName;
                db.Entry(tSql_Banner).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tSql_Banner);
        }

        // GET: Admin/TSql_Banner/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Banner tSql_Banner = await db.TSql_Banner.FindAsync(id);
            if (tSql_Banner == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Banner);
        }

        // POST: Admin/TSql_Banner/Delete/5
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TSql_Banner tSql_Banner = await db.TSql_Banner.FindAsync(id);
            db.TSql_Banner.Remove(tSql_Banner);
            await db.SaveChangesAsync();
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
