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
    public class useruploadsMController : Controller
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: useruploadsM
        public ActionResult Index()
        {
            return View(db.useruploads.ToList());
        }

        // GET: useruploadsM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userupload userupload = db.useruploads.Find(id);
            if (userupload == null)
            {
                return HttpNotFound();
            }
            return View(userupload);
        }

        // GET: useruploadsM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: useruploadsM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "image_id,image_type,image_name,image_name_malay,image_dir,image_desc,image_desc_malay,uploader,upload_time")] userupload userupload)
        {
            if (ModelState.IsValid)
            {
                db.useruploads.Add(userupload);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userupload);
        }

        // GET: useruploadsM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userupload userupload = db.useruploads.Find(id);
            if (userupload == null)
            {
                return HttpNotFound();
            }
            return View(userupload);
        }

        // POST: useruploadsM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "image_id,image_type,image_name,image_name_malay,image_dir,image_desc,image_desc_malay,uploader,upload_time")] userupload userupload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userupload).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userupload);
        }

        // GET: useruploadsM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userupload userupload = db.useruploads.Find(id);
            if (userupload == null)
            {
                return HttpNotFound();
            }
            return View(userupload);
        }

        // POST: useruploadsM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userupload userupload = db.useruploads.Find(id);
            db.useruploads.Remove(userupload);
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
