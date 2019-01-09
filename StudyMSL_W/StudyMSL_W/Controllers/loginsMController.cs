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
    public class loginsMController : Controller
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: loginsM
        public ActionResult Index()
        {
            return View(db.logins.ToList());
        }

        // GET: loginsM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login login = db.logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: loginsM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loginsM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,uname,pword,email")] login login)
        {
            if (ModelState.IsValid)
            {
                db.logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login);
        }

        // GET: loginsM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login login = db.logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: loginsM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,uname,pword,email")] login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: loginsM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login login = db.logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: loginsM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            login login = db.logins.Find(id);
            db.logins.Remove(login);
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
