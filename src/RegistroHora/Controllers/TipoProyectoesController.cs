using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using RegistroHora.Models;

namespace RegistroHora.Controllers
{
    [Produces("application/json", "application/xml")]
    [Route("api/TipoProyectoes")]
    public class TipoProyectoesController : Controller
    {
        private ApplicationDbContext _context;

        public TipoProyectoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoProyectoes
        [HttpGet]
        public IEnumerable<TipoProyecto> GetTiposProyecto()
        {
            return _context.TiposProyecto;
        }

        // GET: api/TipoProyectoes/5
        [HttpGet("{id}", Name = "GetTipoProyecto")]
        public async Task<IActionResult> GetTipoProyecto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            TipoProyecto tipoProyecto = await _context.TiposProyecto.SingleAsync(m => m.Id == id);

            if (tipoProyecto == null)
            {
                return HttpNotFound();
            }

            return Ok(tipoProyecto);
        }

        // PUT: api/TipoProyectoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProyecto([FromRoute] int id, [FromBody] TipoProyecto tipoProyecto)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != tipoProyecto.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(tipoProyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProyectoExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/TipoProyectoes
        [HttpPost]
        public async Task<IActionResult> PostTipoProyecto([FromBody] TipoProyecto tipoProyecto)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.TiposProyecto.Add(tipoProyecto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoProyectoExists(tipoProyecto.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTipoProyecto", new { id = tipoProyecto.Id }, tipoProyecto);
        }

        // DELETE: api/TipoProyectoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProyecto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            TipoProyecto tipoProyecto = await _context.TiposProyecto.SingleAsync(m => m.Id == id);
            if (tipoProyecto == null)
            {
                return HttpNotFound();
            }

            _context.TiposProyecto.Remove(tipoProyecto);
            await _context.SaveChangesAsync();

            return Ok(tipoProyecto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoProyectoExists(int id)
        {
            return _context.TiposProyecto.Count(e => e.Id == id) > 0;
        }
    }
}