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
    public class spellingquestionsMController : Controller
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: spellingquestionsM
        public ActionResult Index()
        {
            return View(db.spellingquestions.ToList());
        }

        // GET: spellingquestionsM/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            spellingquestion spellingquestion = db.spellingquestions.Find(id);
            if (spellingquestion == null)
            {
                return HttpNotFound();
            }
            return View(spellingquestion);
        }

        // GET: spellingquestionsM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: spellingquestionsM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "question_id,question_type,image_dir,answer,image1_dir,image2_dir,image3_dir,image4_dir,image5_dir,image6_dir,image7_dir,image8_dir")] spellingquestion spellingquestion)
        {
            if (ModelState.IsValid)
            {
                db.spellingquestions.Add(spellingquestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spellingquestion);
        }

        // GET: spellingquestionsM/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            spellingquestion spellingquestion = db.spellingquestions.Find(id);
            if (spellingquestion == null)
            {
                return HttpNotFound();
            }
            return View(spellingquestion);
        }

        // POST: spellingquestionsM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "question_id,question_type,image_dir,answer,image1_dir,image2_dir,image3_dir,image4_dir,image5_dir,image6_dir,image7_dir,image8_dir")] spellingquestion spellingquestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spellingquestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spellingquestion);
        }

        // GET: spellingquestionsM/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            spellingquestion spellingquestion = db.spellingquestions.Find(id);
            if (spellingquestion == null)
            {
                return HttpNotFound();
            }
            return View(spellingquestion);
        }

        // POST: spellingquestionsM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            spellingquestion spellingquestion = db.spellingquestions.Find(id);
            db.spellingquestions.Remove(spellingquestion);
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
