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
    public class progressesController : ApiController
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: api/progresses
        public IQueryable<progress> Getprogresses()
        {
            return db.progresses;
        }

        /*
        // GET: api/progresses/5
        [ResponseType(typeof(progress))]
        public IHttpActionResult Getprogress(int id)
        {
            progress progress = db.progresses.Find(id);
            if (progress == null)
            {
                return NotFound();
            }

            return Ok(progress);
        }*/


        //-------------------------------------------------
        // GET: api/progresses/{user_id}
        //[ResponseType(typeof(progress))]
        [HttpGet]
        [Route("api/progresses/{user}")]
        public async Task<IHttpActionResult> Getprogress(string user)
        {
            var progress = db.progresses.Where(a => a.user_id.Equals(user)).FirstOrDefault();
            if (progress == null)
            {
                return NotFound();
            }

            return Ok(progress);
        }

        // GET: api/progresses/{user_id};{content_id}
        //[ResponseType(typeof(progress))]
        [HttpGet]
        [Route("api/progresses/{user};{content}")]
        public async Task<IHttpActionResult> Getprogress(string user, string content)
        {
            var progress = db.progresses.Where(a => a.user_id.Equals(user) && a.content_id.Equals(content)).FirstOrDefault();
            if (progress == null)
            {
                return NotFound();
            }

            return Ok(progress);
        }
        //-------------------------------------------------


        // PUT: api/progresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprogress(int id, progress progress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != progress.p_id)
            {
                return BadRequest();
            }

            db.Entry(progress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!progressExists(id))
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

        // POST: api/progresses
        [ResponseType(typeof(progress))]
        public IHttpActionResult Postprogress(progress progress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.progresses.Add(progress);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = progress.p_id }, progress);
        }

        // DELETE: api/progresses/5
        [HttpDelete]
        [Route("api/progresses/{id}")]
        [ResponseType(typeof(progress))]
        public IHttpActionResult Deleteprogress(int id)
        {
            progress progress = db.progresses.Find(id);
            if (progress == null)
            {
                return NotFound();
            }

            db.progresses.Remove(progress);
            db.SaveChanges();

            return Ok(progress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool progressExists(int id)
        {
            return db.progresses.Count(e => e.p_id == id) > 0;
        }
    }
}