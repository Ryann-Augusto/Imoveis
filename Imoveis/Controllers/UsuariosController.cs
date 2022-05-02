#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Imoveis.Models;

namespace Imoveis.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly _DbContext _context;

        public UsuariosController(_DbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mdUsuarios = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mdUsuarios == null)
            {
                return NotFound();
            }

            return View(mdUsuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,Nivel")] MdUsuarios mdUsuarios)
        {
                _context.Add(mdUsuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mdUsuarios = await _context.Usuario.FindAsync(id);
            if (mdUsuarios == null)
            {
                return NotFound();
            }
            return View(mdUsuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha,Nivel")] MdUsuarios mdUsuarios)
        {
            if (id != mdUsuarios.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(mdUsuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MdUsuariosExists(mdUsuarios.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mdUsuarios = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mdUsuarios == null)
            {
                return NotFound();
            }

            return View(mdUsuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mdUsuarios = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(mdUsuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MdUsuariosExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }

        public IActionResult Admin()
        {
            return View();
        }
    }
}
