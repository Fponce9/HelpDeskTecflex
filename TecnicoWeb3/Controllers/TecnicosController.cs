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
    public class TecnicosController : ApiController
    {
        public TecnicosController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        private AreaTecnicaEntities db = new AreaTecnicaEntities();

        // GET: api/Tecnicos
        public IQueryable<Tecnico> GetTecnico()
        {
            return db.Tecnico;
        }

        // GET: api/Tecnicos/5
        [ResponseType(typeof(Tecnico))]
        public IHttpActionResult GetTecnico(string id)
        {
            Tecnico tecnico = db.Tecnico.Find(id);
            if (tecnico == null)
            {
                return NotFound();
            }

            return Ok(tecnico);
        }

        // PUT: api/Tecnicos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTecnico(string id, Tecnico tecnico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tecnico.DNI)
            {
                return BadRequest();
            }

            db.Entry(tecnico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoExists(id))
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

        // POST: api/Tecnicos
        [ResponseType(typeof(Tecnico))]
        public IHttpActionResult PostTecnico(Tecnico tecnico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tecnico.Add(tecnico);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TecnicoExists(tecnico.DNI))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tecnico.DNI }, tecnico);
        }

        // DELETE: api/Tecnicos/5
        [ResponseType(typeof(Tecnico))]
        public IHttpActionResult DeleteTecnico(string id)
        {
            Tecnico tecnico = db.Tecnico.Find(id);
            if (tecnico == null)
            {
                return NotFound();
            }

            db.Tecnico.Remove(tecnico);
            db.SaveChanges();

            return Ok(tecnico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TecnicoExists(string id)
        {
            return db.Tecnico.Count(e => e.DNI == id) > 0;
        }
    }
}