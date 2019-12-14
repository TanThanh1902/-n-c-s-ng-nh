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
    public class TSql_ChatController : Controller
    {
        private DBMovieEntities db = new DBMovieEntities();

        // GET: Admin/TSql_Chat
        public ActionResult Index(int? page)
        {
            int num = 15;
            int pagenum = (page ?? 1);
            var tSql_Chat = db.TSql_Chat.Include(t => t.TSql_Informations);
            return View(tSql_Chat.OrderByDescending(t => t.DateChat).ToPagedList(pagenum, num));
        }

        // GET: Admin/TSql_Chat/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Chat tSql_Chat = await db.TSql_Chat.FindAsync(id);
            if (tSql_Chat == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Chat);
        }

        // GET: Admin/TSql_Chat/Create
        public ActionResult Create()
        {
            ViewBag.IDUser = new SelectList(db.TSql_Informations, "IDInfo", "DisplayName");
            return View();
        }

        // POST: Admin/TSql_Chat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDChat,Chat,DateChat,IDUser")] TSql_Chat tSql_Chat)
        {
            if (ModelState.IsValid)
            {
                db.TSql_Chat.Add(tSql_Chat);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDUser = new SelectList(db.TSql_Informations, "IDInfo", "DisplayName", tSql_Chat.IDUser);
            return View(tSql_Chat);
        }

        // GET: Admin/TSql_Chat/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Chat tSql_Chat = await db.TSql_Chat.FindAsync(id);
            if (tSql_Chat == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDUser = new SelectList(db.TSql_Informations, "IDInfo", "DisplayName", tSql_Chat.IDUser);
            return View(tSql_Chat);
        }

        // POST: Admin/TSql_Chat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDChat,Chat,DateChat,IDUser")] TSql_Chat tSql_Chat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tSql_Chat).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDUser = new SelectList(db.TSql_Informations, "IDInfo", "DisplayName", tSql_Chat.IDUser);
            return View(tSql_Chat);
        }

        // GET: Admin/TSql_Chat/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TSql_Chat tSql_Chat = await db.TSql_Chat.FindAsync(id);
            if (tSql_Chat == null)
            {
                return HttpNotFound();
            }
            return View(tSql_Chat);
        }

        // POST: Admin/TSql_Chat/Delete/5
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TSql_Chat tSql_Chat = await db.TSql_Chat.FindAsync(id);
            db.TSql_Chat.Remove(tSql_Chat);
            await db.SaveChangesAsync();
            Session["countChat"] = Int32.Parse(Session["countChat"].ToString()) - 1;
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
