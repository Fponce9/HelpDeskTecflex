using System;
using System.Collections.Generic;
using System.Data;
using System;
using System.Collections.Generic;
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
    public class Solicitud_ReparacionController : ApiController
    {
        
        public Solicitud_ReparacionController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        private AreaTecnicaEntities db = new AreaTecnicaEntities();

        // GET: api/Solicitud_Reparacion
        public IQueryable<Solicitud_Reparacion> GetSolicitud_Reparacion()
        {
            return db.Solicitud_Reparacion;
        }

        // GET: api/Solicitud_Reparacion/5
        [ResponseType(typeof(Solicitud_Reparacion))]
        public IHttpActionResult GetSolicitud_Reparacion(int id)
        {
            Solicitud_Reparacion solicitud_Reparacion = db.Solicitud_Reparacion.Find(id);
            if (solicitud_Reparacion == null)
            {
                return NotFound();
            }

            return Ok(solicitud_Reparacion);
        }

        // PUT: api/Solicitud_Reparacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSolicitud_Reparacion(int id, Solicitud_Reparacion solicitud_Reparacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitud_Reparacion.IdProblema)
            {
                return BadRequest();
            }

            db.Entry(solicitud_Reparacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Solicitud_ReparacionExists(id))
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

        // POST: api/Solicitud_Reparacion
        [ResponseType(typeof(Solicitud_Reparacion))]
        public IHttpActionResult PostSolicitud_Reparacion(Solicitud_Reparacion solicitud_Reparacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Solicitud_Reparacion.Add(solicitud_Reparacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = solicitud_Reparacion.IdProblema }, solicitud_Reparacion);
        }

        // DELETE: api/Solicitud_Reparacion/5
        [ResponseType(typeof(Solicitud_Reparacion))]
        public IHttpActionResult DeleteSolicitud_Reparacion(int id)
        {
            Solicitud_Reparacion solicitud_Reparacion = db.Solicitud_Reparacion.Find(id);
            if (solicitud_Reparacion == null)
            {
                return NotFound();
            }

            db.Solicitud_Reparacion.Remove(solicitud_Reparacion);
            db.SaveChanges();

            return Ok(solicitud_Reparacion);
        }

        //GET: api/SolicitudReparacionProducto/{idProducto}
        [Route("api/SolicitudReparacionProducto/{idProducto}")]
        public IQueryable<Solicitud_Reparacion> GetSolicitud_Reparacion_Producto(int idProducto)
        {
            var q = from p in db.Solicitud_Reparacion where p.Producto_IdProducto.Equals(idProducto) select p;
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
        

        private bool Solicitud_ReparacionExists(int id)
        {
            return db.Solicitud_Reparacion.Count(e => e.IdProblema == id) > 0;
        }
    }
}