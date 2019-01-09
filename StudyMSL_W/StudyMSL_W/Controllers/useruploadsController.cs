using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using StudyMSL_W.Models;

namespace StudyMSL_W.Controllers
{
    public class useruploadsController : ApiController
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: api/useruploads
        public IQueryable<userupload> Getuseruploads()
        {
            return db.useruploads;
        }

        // GET: api/useruploads/5
        [ResponseType(typeof(userupload))]
        public IHttpActionResult Getuserupload(int id)
        {
            userupload userupload = db.useruploads.Find(id);
            if (userupload == null)
            {
                return NotFound();
            }

            return Ok(userupload);
        }

        // PUT: api/useruploads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuserupload(int id, userupload userupload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userupload.image_id)
            {
                return BadRequest();
            }

            db.Entry(userupload).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!useruploadExists(id))
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

        // POST: api/useruploads
        [ResponseType(typeof(userupload))]
        public IHttpActionResult Postuserupload(userupload userupload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.useruploads.Add(userupload);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userupload.image_id }, userupload);
        }


        //-------------------------------------------------
        [Route("api/uploads/user")]
        public async Task<string> Post()
        {
            try
            {
                var httprequest = HttpContext.Current.Request;

                if (httprequest.Files.Count > 0)
                {
                    foreach (string file in httprequest.Files)
                    {
                        var postedfile = httprequest.Files[file];

                        var filename = postedfile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                        var filepath = HttpContext.Current.Server.MapPath("~/uploads/user_uploads/" + filename);

                        postedfile.SaveAs(filepath);

                        //return ("/uploads/user_uploads/" + filename);
                        return "Success";
                    }
                }
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return "No Files";
        }
        //-------------------------------------------------


        // DELETE: api/useruploads/5
        [ResponseType(typeof(userupload))]
        public IHttpActionResult Deleteuserupload(int id)
        {
            userupload userupload = db.useruploads.Find(id);
            if (userupload == null)
            {
                return NotFound();
            }

            db.useruploads.Remove(userupload);
            db.SaveChanges();

            return Ok(userupload);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool useruploadExists(int id)
        {
            return db.useruploads.Count(e => e.image_id == id) > 0;
        }
    }
}