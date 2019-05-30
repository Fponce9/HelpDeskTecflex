using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TecnicoWeb3.Models;
using System.Web.Http.Cors;

namespace TecnicoWeb3.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods:"*" )]
    public class EtapasController : ApiController
    {
        public EtapasController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        private AreaTecnicaEntities db = new AreaTecnicaEntities();

        // GET: api/Etapas
        public IQueryable<Etapa> GetEtapa()
        {
            return db.Etapa;
        }

        // GET: api/Etapas/5
        [ResponseType(typeof(Etapa))]
        public IHttpActionResult GetEtapa(int id)
        {
            Etapa etapa = db.Etapa.Find(id);
            if (etapa == null)
            {
                return NotFound();
            }

            return Ok(etapa);
        }

        // PUT: api/Etapas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEtapa(int id, Etapa etapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etapa.IdEtapa)
            {
                return BadRequest();
            }

            db.Entry(etapa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtapaExists(id))
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

        // POST: api/Etapas
        [ResponseType(typeof(Etapa))]
        public IHttpActionResult PostEtapa(Etapa etapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Etapa.Add(etapa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = etapa.IdEtapa }, etapa);
        }

        // DELETE: api/Etapas/5
        [ResponseType(typeof(Etapa))]
        public IHttpActionResult DeleteEtapa(int id)
        {
            Etapa etapa = db.Etapa.Find(id);
            if (etapa == null)
            {
                return NotFound();
            }

            db.Etapa.Remove(etapa);
            db.SaveChanges();

            return Ok(etapa);
        }

        // GET: api/EtapasSolicitudReparacion/{idSolicitud}
        [Route("api/EtapasSolicitudReparacion/{idSolicitud}")]
        public IQueryable<Etapa> GetSolicitud_Reparacion_Producto(int idSolicitud)
        {
            var q = from p in db.Etapa where p.Solicitud_Reparacion_idProblema.Equals(idSolicitud) select p;
            return q;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EtapaExists(int id)
        {
            return db.Etapa.Count(e => e.IdEtapa == id) > 0;
        }


    }
}