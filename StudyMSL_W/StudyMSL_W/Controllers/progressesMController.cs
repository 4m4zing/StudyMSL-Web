using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudyMSL_W.Models;

namespace StudyMSL_W.Controllers
{
    public class progressesMController : Controller
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: progressesM
        public ActionResult Index()
        {
            return View(db.progresses.ToList());
        }

        // GET: progressesM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            progress progress = db.progresses.Find(id);
            if (progress == null)
            {
                return HttpNotFound();
            }
            return View(progress);
        }

        // GET: progressesM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: progressesM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_id,user_id,content_id,content_name,content_desc,date_completed")] progress progress)
        {
            if (ModelState.IsValid)
            {
                db.progresses.Add(progress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(progress);
        }

        // GET: progressesM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            progress progress = db.progresses.Find(id);
            if (progress == null)
            {
                return HttpNotFound();
            }
            return View(progress);
        }

        // POST: progressesM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_id,user_id,content_id,content_name,content_desc,date_completed")] progress progress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(progress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(progress);
        }

        // GET: progressesM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            progress progress = db.progresses.Find(id);
            if (progress == null)
            {
                return HttpNotFound();
            }
            return View(progress);
        }

        // POST: progressesM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            progress progress = db.progresses.Find(id);
            db.progresses.Remove(progress);
            db.SaveChanges();
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
