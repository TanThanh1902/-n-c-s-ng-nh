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
    public class TSql_InformationsController : Controller
    {
        private DBMovieEntities db = new DBMovieEntities();

        // GET: Admin/TSql_Informations
        public ActionResult Index(int? page)
        {
            int num = 15;
            int pagenum = (page ?? 1);
            return View(db.TSql_Informations.Where(t => t.Role != 1).OrderBy(t => t.DisplayName).ToPagedList(pagenum, num));
        }

        // GET: Admin/TSql_Informations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Informations tSql_Informations = await db.TSql_Informations.FindAsync(id);
            if (tSql_Informations == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Informations);
        }

        // GET: Admin/TSql_Informations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TSql_Informations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDInfo,DisplayName,UserName,Password,Role,DateCreate,ForgotPasswordCode")] TSql_Informations tSql_Informations)
        {
            if (ModelState.IsValid)
            {
                db.TSql_Informations.Add(tSql_Informations);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tSql_Informations);
        }

        // GET: Admin/TSql_Informations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Informations tSql_Informations = await db.TSql_Informations.FindAsync(id);
            if (tSql_Informations == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Informations);
        }

        // POST: Admin/TSql_Informations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "IDInfo,DisplayName,UserName,Password,ConfirmPassword,Role,DateCreate,ForgotPasswordCode")] TSql_Informations tSql_Informations)
         {
            if(tSql_Informations.Password != tSql_Informations.ConfirmPassword)
            {
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                db.Entry(tSql_Informations).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tSql_Informations);
        }

        // GET: Admin/TSql_Informations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Informations tSql_Informations = await db.TSql_Informations.FindAsync(id);
            if (tSql_Informations == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Informations);
        }

        // POST: Admin/TSql_Informations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TSql_Informations tSql_Informations = await db.TSql_Informations.FindAsync(id);
            db.TSql_Informations.Remove(tSql_Informations);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public PartialViewResult SetName()
        {
            return PartialView();
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
