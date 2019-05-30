using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TecnicoWeb3.Models;

namespace TecnicoWeb3.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class RepuestosController : ApiController
    {        
        public RepuestosController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        private AreaTecnicaEntities db = new AreaTecnicaEntities();

        // GET: api/Repuestos
        public IQueryable<Repuestos> GetRepuestos()
        {
            return db.Repuestos;
        }

        // GET: api/Repuestos/5
        [ResponseType(typeof(Repuestos))]
        public IHttpActionResult GetRepuestos(int id)
        {
            Repuestos repuestos = db.Repuestos.Find(id);
            if (repuestos == null)
            {
                return NotFound();
            }

            return Ok(repuestos);
        }

        // PUT: api/Repuestos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRepuestos(int id, Repuestos repuestos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repuestos.idRepuesto)
            {
                return BadRequest();
            }

            db.Entry(repuestos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepuestosExists(id))
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

        // POST: api/Repuestos
        [ResponseType(typeof(Repuestos))]
        public IHttpActionResult PostRepuestos(Repuestos repuestos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Repuestos.Add(repuestos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = repuestos.idRepuesto }, repuestos);
        }

        // DELETE: api/Repuestos/5
        [ResponseType(typeof(Repuestos))]
        public IHttpActionResult DeleteRepuestos(int id)
        {
            Repuestos repuestos = db.Repuestos.Find(id);
            if (repuestos == null)
            {
                return NotFound();
            }

            db.Repuestos.Remove(repuestos);
            db.SaveChanges();

            return Ok(repuestos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepuestosExists(int id)
        {
            return db.Repuestos.Count(e => e.idRepuesto == id) > 0;
        }
    }
}