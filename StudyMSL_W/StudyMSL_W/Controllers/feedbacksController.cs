using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StudyMSL_W.Models;

namespace StudyMSL_W.Controllers
{
    public class feedbacksController : ApiController
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: api/feedbacks
        public IQueryable<feedback> Getfeedbacks()
        {
            return db.feedbacks;
        }

        // GET: api/feedbacks/5
        [ResponseType(typeof(feedback))]
        public IHttpActionResult Getfeedback(int id)
        {
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // PUT: api/feedbacks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfeedback(int id, feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.feedback_id)
            {
                return BadRequest();
            }

            db.Entry(feedback).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!feedbackExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/feedbacks
        [ResponseType(typeof(feedback))]
        public IHttpActionResult Postfeedback(feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.feedbacks.Add(feedback);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = feedback.feedback_id }, feedback);
        }

        // DELETE: api/feedbacks/5
        [ResponseType(typeof(feedback))]
        public IHttpActionResult Deletefeedback(int id)
        {
            feedback feedback = db.feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }

            db.feedbacks.Remove(feedback);
            db.SaveChanges();

            return Ok(feedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool feedbackExists(int id)
        {
            return db.feedbacks.Count(e => e.feedback_id == id) > 0;
        }
    }
}