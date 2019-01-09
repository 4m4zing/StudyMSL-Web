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
    public class learnsController : ApiController
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: api/learns
        public IQueryable<learn> Getlearns()
        {
            return db.learns;
        }

        /*
        // GET: api/learns/5
        [ResponseType(typeof(learn))]
        public IHttpActionResult Getlearn(string id)
        {
            learn learn = db.learns.Find(id);
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }*/


        //-------------------------------------------------
        // GET: api/learns/alphabet/{id}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/{id}")]
        public async Task<IHttpActionResult> Getlearn(string id)
        {
            var learn = db.learns.Where(a => a.image_id.Contains(id)).AsEnumerable();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }


        // GET: api/learns/searchbyname/all/{name};{type}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/searchbyname/all/{name};{type}")]
        public async Task<IHttpActionResult> GetlearnNameAll(string name, string type)
        {
            var learn = db.learns.Where(a => (a.image_name.Contains(name) || a.image_name_malay.Contains(name)) && a.image_type.Equals(type)).AsEnumerable();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }


        // GET: api/learns/searchbyname/{name};{type}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/searchbyname/{name};{type}")]
        public async Task<IHttpActionResult> GetlearnName(string name, string type)
        {
            var learn = db.learns.Where(a => a.image_name.Contains(name) && a.image_type.Equals(type)).AsEnumerable();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }


        // GET: api/learns/searchbyname/malay/{name};{type}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/searchbyname/malay/{name};{type}")]
        public async Task<IHttpActionResult> GetlearnNameMalay(string name, string type)
        {
            var learn = db.learns.Where(a => a.image_name_malay.Contains(name) && a.image_type.Equals(type)).AsEnumerable();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }


        // GET: api/learns/searchbynameexact/{name}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/searchbynameexact/{name};{type}")]
        public async Task<IHttpActionResult> GetlearnExact(string name, string type)
        {
            var learn = db.learns.Where(a => a.image_name.Equals(name) && a.image_type.Equals(type)).FirstOrDefault();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }


        // GET: api/learns/searchbynameexact/malay/{name}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/searchbynameexact/malay/{name};{type}")]
        public async Task<IHttpActionResult> GetlearnExactMalay(string name, string type)
        {
            var learn = db.learns.Where(a => a.image_name_malay.Equals(name) && a.image_type.Equals(type)).FirstOrDefault();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }


        // GET: api/learns/alphabet/searchbyname/{name}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/alphabet/searchbyname/{name}")]
        public async Task<IHttpActionResult> GetlearnAlphabet(string name)
        {
            var learn = db.learns.Where(a => a.image_name.Contains(name) && a.image_type.Equals("alphabet")).AsEnumerable();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }

        // GET: api/learns/number/searchbyname/{name}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/number/searchbyname/{name}")]
        public async Task<IHttpActionResult> GetlearnNumber(string name)
        {
            var learn = db.learns.Where(a => a.image_name.Contains(name) && a.image_type.Equals("number")).AsEnumerable();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }

        // GET: api/learns/word/searchbyname/{name}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/word/searchbyname/{name}")]
        public async Task<IHttpActionResult> GetlearnWord(string name)
        {
            var learn = db.learns.Where(a => a.image_name.Contains(name) && a.image_type.Equals("word")).AsEnumerable();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }

        // GET: api/learns/word/searchbynameexact/{name}
        //[ResponseType(typeof(learn))]
        [HttpGet]
        [Route("api/learns/word/searchbynameexact/{name}")]
        public async Task<IHttpActionResult> GetlearnWordExact(string name)
        {
            var learn = db.learns.Where(a => a.image_name.Equals(name) && a.image_type.Equals("word")).AsEnumerable();
            if (learn == null)
            {
                return NotFound();
            }

            return Ok(learn);
        }
        //-------------------------------------------------


        // PUT: api/learns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlearn(string id, learn learn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != learn.image_id)
            {
                return BadRequest();
            }

            db.Entry(learn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!learnExists(id))
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

        // POST: api/learns
        [ResponseType(typeof(learn))]
        public IHttpActionResult Postlearn(learn learn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.learns.Add(learn);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (learnExists(learn.image_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = learn.image_id }, learn);
        }

        // DELETE: api/learns/5
        [ResponseType(typeof(learn))]
        public IHttpActionResult Deletelearn(string id)
        {
            learn learn = db.learns.Find(id);
            if (learn == null)
            {
                return NotFound();
            }

            db.learns.Remove(learn);
            db.SaveChanges();

            return Ok(learn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool learnExists(string id)
        {
            return db.learns.Count(e => e.image_id == id) > 0;
        }
    }
}