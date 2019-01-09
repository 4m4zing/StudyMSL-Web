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
    public class spellingquestionsController : ApiController
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: api/spellingquestions
        public IQueryable<spellingquestion> Getspellingquestions()
        {
            return db.spellingquestions;
        }

        /*
        // GET: api/spellingquestions/5
        [ResponseType(typeof(spellingquestion))]
        public IHttpActionResult Getspellingquestion(string id)
        {
            spellingquestion spellingquestion = db.spellingquestions.Find(id);
            if (spellingquestion == null)
            {
                return NotFound();
            }

            return Ok(spellingquestion);
        }*/


        //-------------------------------------------------
        // GET: api/spellingquestions/{type}
        //[ResponseType(typeof(spellingquestion))]
        [HttpGet]
        [Route("api/spellingquestions/{type}")]
        public async Task<IHttpActionResult> Getspellingquestion(string type)
        {
            var spellingquestion = db.spellingquestions.Where(a => a.question_type.Equals(type)).AsEnumerable();
            if (spellingquestion == null)
            {
                return NotFound();
            }

            return Ok(spellingquestion);
        }
        //-------------------------------------------------


        // PUT: api/spellingquestions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putspellingquestion(string id, spellingquestion spellingquestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spellingquestion.question_id)
            {
                return BadRequest();
            }

            db.Entry(spellingquestion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!spellingquestionExists(id))
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

        // POST: api/spellingquestions
        [ResponseType(typeof(spellingquestion))]
        public IHttpActionResult Postspellingquestion(spellingquestion spellingquestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.spellingquestions.Add(spellingquestion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (spellingquestionExists(spellingquestion.question_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = spellingquestion.question_id }, spellingquestion);
        }

        // DELETE: api/spellingquestions/5
        [ResponseType(typeof(spellingquestion))]
        public IHttpActionResult Deletespellingquestion(string id)
        {
            spellingquestion spellingquestion = db.spellingquestions.Find(id);
            if (spellingquestion == null)
            {
                return NotFound();
            }

            db.spellingquestions.Remove(spellingquestion);
            db.SaveChanges();

            return Ok(spellingquestion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool spellingquestionExists(string id)
        {
            return db.spellingquestions.Count(e => e.question_id == id) > 0;
        }
    }
}