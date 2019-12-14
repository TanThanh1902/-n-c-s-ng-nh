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
using System.IO;

namespace Moviepro.Areas.Admin.Controllers
{
    public class TSql_FilmsController : Controller
    {
        private DBMovieEntities db = new DBMovieEntities();

        // GET: Admin/TSql_Films
        public ActionResult Index(int? page)
        {
            int num = 10;
            int numpage = (page ?? 1);
            var tSql_Films = db.TSql_Films.Include(t => t.TSql_Country);
            return View(tSql_Films.OrderBy(t => t.FilmName).ToPagedList(numpage, num));
        }

        // GET: Admin/TSql_Films/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TSql_Films tSql_Films = await db.TSql_Films.FindAsync(id);
            if (tSql_Films == null)
                return HttpNotFound();
            return View(tSql_Films);
        }

        // GET: Admin/TSql_Films/Create
        public ActionResult Create()
        {
            TSql_Films model = new TSql_Films();
            ViewBag.IDCategory = new MultiSelectList(db.TSql_Categorys.ToList(), "IDCategory", "CategoryName", model.TSql_Film_Category.Select(t => t.IDCategory).ToArray());
            ViewBag.IDCountry = new SelectList(db.TSql_Country, "IDCountry", "CountryName");
            return View(model);
        }

        // POST: Admin/TSql_Films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDFilm,FilmName,Description,Time,Author,DateSubmited,Image,IDCountry,Rating,Views,LinkFilm,Trailer,Download,IDCategory,Votes")] TSql_Films tSql_Films, int[] IDCategory, HttpPostedFileBase fileimg)
        {
            if (ModelState.IsValid)
            {
                // add file img
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
                tSql_Films.Image = fileimg.FileName;
                tSql_Films.DateSubmited = DateTime.Now;
                db.TSql_Films.Add(tSql_Films);
                await db.SaveChangesAsync();
                foreach (var item in IDCategory)
                {
                    TSql_Film_Category tfc = new TSql_Film_Category();
                    tfc.IDFilm = tSql_Films.IDFilm;
                    tfc.IDCategory = item;
                    tfc.DateUpdate = DateTime.Now;
                    tfc.DateCreate = DateTime.Now;
                    db.TSql_Film_Category.Add(tfc);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCountry = new SelectList(db.TSql_Country, "IDCountry", "CountryName", tSql_Films.IDCountry);
            return View(tSql_Films);
        }

        // GET: Admin/TSql_Films/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Films tSql_Films = await db.TSql_Films.FindAsync(id);
            if (tSql_Films == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategory = new MultiSelectList(db.TSql_Categorys.ToList(), "IDCategory", "CategoryName", tSql_Films.TSql_Film_Category.Select(t => t.IDCategory).ToArray());
            ViewBag.IDCountry = new SelectList(db.TSql_Country, "IDCountry", "CountryName", tSql_Films.IDCountry);
            return View(tSql_Films);
        }

        // POST: Admin/TSql_Films/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDFilm,FilmName,Description,Time,Author,DateSubmited,Image,IDCountry,Rating,Views,LinkFilm,Trailer,Download, IDCategory")] TSql_Films tSql_Films, int[] IDCategory, HttpPostedFileBase fileimg)
        {
            if (ModelState.IsValid)
            {
                TSql_Films tmpFilm = db.TSql_Films.Find(tSql_Films.IDFilm);
                if (fileimg != null)
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
                    tmpFilm.Image = fileimg.FileName;
                }
                tmpFilm.FilmName = tSql_Films.FilmName;
                tmpFilm.Description = tSql_Films.Description;
                tmpFilm.Time = tSql_Films.Time;
                tmpFilm.Author = tSql_Films.Author;
                tmpFilm.LinkFilm = tSql_Films.LinkFilm;
                tmpFilm.Download = tSql_Films.Download;
                tmpFilm.Trailer = tSql_Films.Trailer;
                tmpFilm.IDCountry = tSql_Films.IDCountry;
                db.Entry(tmpFilm).State = EntityState.Modified;
                await db.SaveChangesAsync();

                if (tmpFilm != null)
                {
                    // remove item

                    var removeitems = tmpFilm.TSql_Film_Category.Where(t => !IDCategory.Contains(t.IDCategory)).ToList();

                    foreach (var i in removeitems)
                    {
                        db.Entry(i).State = EntityState.Deleted;
                    }

                    // add item

                    var additems = IDCategory.Where(t => !tmpFilm.TSql_Film_Category.Select(x => x.IDCategory).Contains(t));

                    foreach (var item in additems)
                    {
                        TSql_Film_Category tfc = new TSql_Film_Category();
                        tfc.IDFilm = tmpFilm.IDFilm;
                        tfc.IDCategory = item;
                        tfc.DateUpdate = DateTime.Now;
                        db.TSql_Film_Category.Add(tfc);
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.IDCountry = new SelectList(db.TSql_Country, "IDCountry", "CountryName", tSql_Films.IDCountry);
            return View(tSql_Films);
        }

        // GET: Admin/TSql_Films/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Films tSql_Films = await db.TSql_Films.FindAsync(id);
            if (tSql_Films == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategory = new MultiSelectList(db.TSql_Categorys.ToList(), "IDCategory", "CategoryName", tSql_Films.TSql_Film_Category.Select(t => t.IDCategory).ToArray());
            return View(tSql_Films);
        }

        // POST: Admin/TSql_Films/Delete/5
        public async Task<ActionResult> DeleteConfirmed(int id, int[] IDCategory)
        {
            TSql_Films tSql_Films = await db.TSql_Films.FindAsync(id);
            TSql_Films tmpFilm = db.TSql_Films.Find(tSql_Films.IDFilm);
            //var removeitems = tmpFilm.TSql_Film_Category.Where(t => !IDCategory.Contains(t.IDCategory)).ToList();
            var tmp = tmpFilm.TSql_Film_Category.Where(t => t.IDFilm == tSql_Films.IDFilm).ToList();
            foreach (var i in tmp)
            {
                db.Entry(i).State = EntityState.Deleted;
            }
            db.TSql_Films.Remove(tSql_Films);
            await db.SaveChangesAsync();
            Session["countFilm"] = Int32.Parse(Session["countFilm"].ToString()) - 1;
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
