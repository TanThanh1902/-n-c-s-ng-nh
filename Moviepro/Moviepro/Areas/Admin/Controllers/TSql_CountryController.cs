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
    public class TSql_CountryController : Controller
    {
        private DBMovieEntities db = new DBMovieEntities();

        // GET: Admin/TSql_Country
        public async Task<ActionResult> Index()
        {
            return View(await db.TSql_Country.ToListAsync());
        }

        // GET: Admin/TSql_Country/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Country tSql_Country = await db.TSql_Country.FindAsync(id);
            if (tSql_Country == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Country);
        }

        // GET: Admin/TSql_Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TSql_Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCountry,CountryName")] TSql_Country tSql_Country)
        {
            if (ModelState.IsValid)
            {
                db.TSql_Country.Add(tSql_Country);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tSql_Country);
        }

        // GET: Admin/TSql_Country/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Country tSql_Country = await db.TSql_Country.FindAsync(id);
            if (tSql_Country == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Country);
        }

        // POST: Admin/TSql_Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCountry,CountryName")] TSql_Country tSql_Country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSql_Country).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tSql_Country);
        }

        // GET: Admin/TSql_Country/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Country tSql_Country = await db.TSql_Country.FindAsync(id);
            if (tSql_Country == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Country);
        }

        // POST: Admin/TSql_Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TSql_Country tSql_Country = await db.TSql_Country.FindAsync(id);
            db.TSql_Country.Remove(tSql_Country);
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
