using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RegistroHora.Models;

namespace RegistroHora.Controllers
{
    public class ProyectoController : Controller
    {
        private ApplicationDbContext _context;

        public ProyectoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Proyecto
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Proyectos.Include(p => p.Cliente).Include(p => p.TipoProyecto);
            ViewData["Title"] = "Proyectos";
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Proyecto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Proyecto proyecto = await _context.Proyectos.SingleAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewData["Title"] = "Detalle de " + proyecto.Nombre;
            return View(proyecto);
        }

        // GET: Proyecto/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Crear";
            ViewBag.ClienteId = new SelectList(_context.Cliente, "Id", "Nombre");
            ViewBag.TipoProyectoId = new SelectList(_context.TiposProyecto, "Id", "Nombre");
            return View( new Proyecto());
        }

        // POST: Proyecto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Proyectos.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_context.Cliente, "Id", "Nombre", proyecto.ClienteId);
            ViewBag.TipoProyectoId = new SelectList(_context.TiposProyecto, "Id", "Nombre", proyecto.TipoProyectoId);
            return View(proyecto);
        }

        // GET: Proyecto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }

            Proyecto proyecto = await _context.Proyectos.SingleAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewData["Title"] = "Editar "+ proyecto.Nombre;
            ViewBag.ClienteId = new SelectList(_context.Cliente, "Id", "Nombre", proyecto.ClienteId);
            ViewBag.TipoProyectoId = new SelectList(_context.TiposProyecto, "Id", "Nombre", proyecto.TipoProyectoId);
            return View(proyecto);
        }

        // POST: Proyecto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Update(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_context.Cliente, "Id", "Nombre", proyecto.ClienteId);
            ViewBag.TipoProyectoId = new SelectList(_context.TiposProyecto, "Id", "Nombre", proyecto.TipoProyectoId);
            return View(proyecto);
        }

        // GET: Proyecto/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Proyecto proyecto = await _context.Proyectos.SingleAsync(m => m.Id == id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }

            ViewData["Title"] = "Eliminar " + proyecto.Nombre;
            return View(proyecto);
        }

        // POST: Proyecto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Proyecto proyecto = await _context.Proyectos.SingleAsync(m => m.Id == id);
            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
