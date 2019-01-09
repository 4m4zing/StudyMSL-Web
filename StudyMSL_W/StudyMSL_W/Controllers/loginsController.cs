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
    public class loginsController : ApiController
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: api/logins
        public IQueryable<login> Getlogins()
        {
            return db.logins;
        }

        /*
        // GET: api/logins/5
        [ResponseType(typeof(login))]
        public IHttpActionResult Getlogin(int id)
        {
            login login = db.logins.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }*/


        //-------------------------------------------------
        // GET: api/logins/{uname}
        //[ResponseType(typeof(login))]
        [HttpGet]
        [Route("api/logins/{uname}")]
        public async Task<IHttpActionResult> GetLogin(string uname)
        {
            var login = db.logins.Where(a => a.uname.Equals(uname)).SingleOrDefault();
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // GET: api/logins/{uname};{pword}
        //[ResponseType(typeof(login))]
        [HttpGet]
        [Route("api/logins/{uname};{pword}")]
        public async Task<IHttpActionResult> GetLogin(string uname, string pword)
        {
            var login = db.logins.Where(a => a.uname.Equals(uname) && a.pword.Equals(pword)).SingleOrDefault();
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }
        //-------------------------------------------------


        // PUT: api/logins/5
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/logins/{id}")]
        public IHttpActionResult Putlogin(int id, [FromBody]login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.user_id)
            {
                return BadRequest();
            }

            db.Entry(login).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!loginExists(id))
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

        /*
        // POST: api/logins
        [ResponseType(typeof(login))]
        public IHttpActionResult Postlogin(login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.logins.Add(login);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = login.user_id }, login);
        }*/


        //-------------------------------------------------
        // POST: api/logins
        [ResponseType(typeof(login))]
        public IHttpActionResult Postlogin(login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existedlogin = db.logins.Where(a => a.uname.Equals(login.uname)).SingleOrDefault();
            if (existedlogin == null)
            {
                db.logins.Add(login);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = login.user_id }, login);
            }

            return NotFound();
            //return null;
        }
        //-------------------------------------------------


        // DELETE: api/logins/5
        [HttpDelete]
        [ResponseType(typeof(login))]
        [Route("api/logins/{id}")]
        public IHttpActionResult Deletelogin(int id)
        {
            login login = db.logins.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            db.logins.Remove(login);
            db.SaveChanges();

            return Ok(login);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool loginExists(int id)
        {
            return db.logins.Count(e => e.user_id == id) > 0;
        }
    }
}