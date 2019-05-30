using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TecnicoWeb3.Models;

namespace TecnicoWeb3.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class SeguridadController : ApiController
    {
        public SeguridadController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        private AreaTecnicaEntities db = new AreaTecnicaEntities();

        // GET: api/Seguridad
        public IQueryable<Seguridad> GetSeguridad()
        {
            return db.Seguridad;
        }

        // GET: api/Seguridad/5
        [ResponseType(typeof(Seguridad))]
        public IHttpActionResult GetSeguridad(DateTime id)
        {
            Seguridad seguridad = db.Seguridad.Find(id);
            if (seguridad == null)
            {
                return NotFound();
            }

            return Ok(seguridad);
        }

        // PUT: api/Seguridad/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSeguridad(DateTime id, Seguridad seguridad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seguridad.Tiempo)
            {
                return BadRequest();
            }

            db.Entry(seguridad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguridadExists(id))
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

        // POST: api/Seguridad
        [ResponseType(typeof(Seguridad))]
        public IHttpActionResult PostSeguridad(Seguridad seguridad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Seguridad.Add(seguridad);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SeguridadExists(seguridad.Tiempo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = seguridad.Tiempo }, seguridad);
        }

        // DELETE: api/Seguridad/5
        [ResponseType(typeof(Seguridad))]
        public IHttpActionResult DeleteSeguridad(DateTime id)
        {
            Seguridad seguridad = db.Seguridad.Find(id);
            if (seguridad == null)
            {
                return NotFound();
            }

            db.Seguridad.Remove(seguridad);
            db.SaveChanges();

            return Ok(seguridad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeguridadExists(DateTime id)
        {
            return db.Seguridad.Count(e => e.Tiempo == id) > 0;
        }
    }
}