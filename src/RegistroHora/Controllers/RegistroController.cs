using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using RegistroHora.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Authorization;

namespace RegistroHora.Controllers
{
    public class RegistroController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _manager;

        public RegistroController(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: Registro
        public async Task<IActionResult> Index(string FechaInicio, string FechaFin)
        {
            var applicationDbContext = _context.Registros.Include(r => r.Proyecto).Include(r => r.Usuario).Where(x=>x.Horas>0);
            if (!string.IsNullOrEmpty(FechaFin) && !string.IsNullOrEmpty(FechaInicio))
            {
                applicationDbContext = _context.Registros.Include(r => r.Proyecto).Include(r => r.Usuario).Where(x => x.Fecha >= DateTime.Parse(FechaInicio) && x.Fecha <= DateTime.Parse(FechaFin));
            }
            ViewData["Title"] = "Registros";
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Registro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Registro registro = await _context.Registros.SingleAsync(m => m.Id == id);
            if (registro == null)
            {
                return HttpNotFound();
            }

            return View(registro);
        }

        // GET: Registro/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.ProyectoId = new SelectList(_context.Proyectos, "Id", "Nombre");
            //ViewBag.UsuarioId = new SelectList(_context.Users, "Id", "Usuario");
            Registro registro = new Registro();
            registro.UsuarioId = _manager.FindByNameAsync(HttpContext.User.Identity.Name).Result.Id;
            registro.Usuario = _manager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
            return View(registro);
        }

        // POST: Registro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Registro registro)
        {
            if (ModelState.IsValid)
            {
                _context.Registros.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProyectoId = new SelectList(_context.Proyectos, "Id", "Nombre", registro.ProyectoId);
            ViewBag.UsuarioId = new SelectList(_context.Users, "Id", "Usuario", registro.UsuarioId);
            return View(registro);
        }

        // GET: Registro/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Registro registro = await _context.Registros.SingleAsync(m => m.Id == id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProyectoId = new SelectList(_context.Proyectos, "Id", "Nombre", registro.ProyectoId);
            ViewBag.UsuarioId = new SelectList(_context.Users, "Id", "Usuario", registro.UsuarioId);
            return View(registro);
        }

        // POST: Registro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(Registro registro)
        {
            if (ModelState.IsValid)
            {
                _context.Update(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProyectoId = new SelectList(_context.Proyectos, "Id", "Nombre", registro.ProyectoId);
            ViewBag.UsuarioId = new SelectList(_context.Users, "Id", "Usuario", registro.UsuarioId);
            return View(registro);
        }

        // GET: Registro/Delete/5
        [ActionName("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Registro registro = await _context.Registros.SingleAsync(m => m.Id == id);
            if (registro == null)
            {
                return HttpNotFound();
            }

            return View(registro);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Registro registro = await _context.Registros.SingleAsync(m => m.Id == id);
            _context.Registros.Remove(registro);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
