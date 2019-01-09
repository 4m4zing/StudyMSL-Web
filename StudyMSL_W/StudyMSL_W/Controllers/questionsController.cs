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
    public class questionsController : ApiController
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: api/questions
        public IQueryable<question> Getquestions()
        {
            return db.questions;
        }

        /*
        // GET: api/questions/5
        [ResponseType(typeof(question))]
        public IHttpActionResult Getquestion(string id)
        {
            question question = db.questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }*/


        //-------------------------------------------------
        // GET: api/questions/{type}
        //[ResponseType(typeof(quetion))]
        [HttpGet]
        [Route("api/questions/{type}")]
        public async Task<IHttpActionResult> Getquestion(string type)
        {
            var question = db.questions.Where(a => a.question_type.Equals(type)).AsEnumerable();
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }
        //-------------------------------------------------


        // PUT: api/questions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putquestion(string id, question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.question_id)
            {
                return BadRequest();
            }

            db.Entry(question).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!questionExists(id))
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

        // POST: api/questions
        [ResponseType(typeof(question))]
        public IHttpActionResult Postquestion(question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.questions.Add(question);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (questionExists(question.question_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = question.question_id }, question);
        }

        // DELETE: api/questions/5
        [ResponseType(typeof(question))]
        public IHttpActionResult Deletequestion(string id)
        {
            question question = db.questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            db.questions.Remove(question);
            db.SaveChanges();

            return Ok(question);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool questionExists(string id)
        {
            return db.questions.Count(e => e.question_id == id) > 0;
        }
    }
}