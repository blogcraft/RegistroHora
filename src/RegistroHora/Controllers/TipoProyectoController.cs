using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RegistroHora.Models;

namespace RegistroHora.Controllers
{
    [Produces("application/json")]
    public class TipoProyectoController : Controller
    {
        private ApplicationDbContext _context;

        public TipoProyectoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TipoProyecto
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposProyecto.ToListAsync());
        }

        [Route("api/TipoProyecto")]
        // GET: api/TipoProyectoes
        [HttpGet]
        public IEnumerable<TipoProyecto> GetTiposProyecto()
        {
            return _context.TiposProyecto;
        }

        // GET: TipoProyecto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TipoProyecto tipoProyecto = await _context.TiposProyecto.SingleAsync(m => m.Id == id);
            if (tipoProyecto == null)
            {
                return HttpNotFound();
            }

            return View(tipoProyecto);
        }

        // GET: TipoProyecto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoProyecto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoProyecto tipoProyecto)
        {
            if (ModelState.IsValid)
            {
                _context.TiposProyecto.Add(tipoProyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Proyecto");
            }
            return View(tipoProyecto);
        }

        // GET: TipoProyecto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TipoProyecto tipoProyecto = await _context.TiposProyecto.SingleAsync(m => m.Id == id);
            if (tipoProyecto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProyecto);
        }

        // POST: TipoProyecto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TipoProyecto tipoProyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Update(tipoProyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoProyecto);
        }

        // GET: TipoProyecto/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TipoProyecto tipoProyecto = await _context.TiposProyecto.SingleAsync(m => m.Id == id);
            if (tipoProyecto == null)
            {
                return HttpNotFound();
            }

            return View(tipoProyecto);
        }

        // POST: TipoProyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TipoProyecto tipoProyecto = await _context.TiposProyecto.SingleAsync(m => m.Id == id);
            _context.TiposProyecto.Remove(tipoProyecto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
