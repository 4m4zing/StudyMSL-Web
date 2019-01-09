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
    public class feedbacksMController : Controller
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: feedbacksM
        public ActionResult Index()
        {
            return View(db.feedbacks.ToList());
        }

        // GET: feedbacksM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: feedbacksM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: feedbacksM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "feedback_id,email,comment")] feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedback);
        }

        // GET: feedbacksM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: feedbacksM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "feedback_id,email,comment")] feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: feedbacksM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: feedbacksM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feedback feedback = db.feedbacks.Find(id);
            db.feedbacks.Remove(feedback);
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
