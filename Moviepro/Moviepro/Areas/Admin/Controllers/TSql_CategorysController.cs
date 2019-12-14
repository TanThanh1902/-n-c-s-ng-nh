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

namespace Moviepro.Areas.Admin.Controllers
{
    public class TSql_CategorysController : Controller
    {
        private DBMovieEntities db = new DBMovieEntities();

        // GET: Admin/TSql_Categorys
        public async Task<ActionResult> Index()
        {
            return View(await db.TSql_Categorys.ToListAsync());
        }

        // GET: Admin/TSql_Categorys/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Categorys tSql_Categorys = await db.TSql_Categorys.FindAsync(id);
            if (tSql_Categorys == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Categorys);
        }

        // GET: Admin/TSql_Categorys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TSql_Categorys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCategory,CategoryName")] TSql_Categorys tSql_Categorys)
        {
            if (ModelState.IsValid)
            {
                db.TSql_Categorys.Add(tSql_Categorys);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tSql_Categorys);
        }

        // GET: Admin/TSql_Categorys/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Categorys tSql_Categorys = await db.TSql_Categorys.FindAsync(id);
            if (tSql_Categorys == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Categorys);
        }

        // POST: Admin/TSql_Categorys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCategory,CategoryName")] TSql_Categorys tSql_Categorys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSql_Categorys).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tSql_Categorys);
        }

        // GET: Admin/TSql_Categorys/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Categorys tSql_Categorys = await db.TSql_Categorys.FindAsync(id);
            if (tSql_Categorys == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Categorys);
        }

        // POST: Admin/TSql_Categorys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TSql_Categorys tSql_Categorys = await db.TSql_Categorys.FindAsync(id);
            db.TSql_Categorys.Remove(tSql_Categorys);
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
