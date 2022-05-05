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
    public class ImoveisController : Controller
    {
        private readonly _DbContext _context;

        public ImoveisController(_DbContext context)
        {
            _context = context;
        }

        // GET: Imoveis
        public async Task<IActionResult> Index()
        {
            var _DbContext = _context.Imovel.Include(m => m.Usuario);
            return View(await _DbContext.ToListAsync());
        }

        // GET: Imoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mdImoveis = await _context.Imovel
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mdImoveis == null)
            {
                return NotFound();
            }

            return View(mdImoveis);
        }

        // GET: Imoveis/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Imoveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Valor,Quarto,Vagas,Tipo,Rua,Bairro,Cidade,Estado,CEP,UsuarioId")] MdImoveis mdImoveis)
        {
            _context.Add(mdImoveis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Imoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mdImoveis = await _context.Imovel.FindAsync(id);
            if (mdImoveis == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome", mdImoveis.UsuarioId);
            return View(mdImoveis);
        }

        // POST: Imoveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Valor,Quarto,Vagas,Tipo,Rua,Bairro,Cidade,Estado,CEP,UsuarioId")] MdImoveis mdImoveis)
        {
            if (id != mdImoveis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(mdImoveis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MdImoveisExists(mdImoveis.Id))
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
            return View(mdImoveis);
        }

        // GET: Imoveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mdImoveis = await _context.Imovel
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mdImoveis == null)
            {
                return NotFound();
            }

            return View(mdImoveis);
        }

        // POST: Imoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mdImoveis = await _context.Imovel.FindAsync(id);
            _context.Imovel.Remove(mdImoveis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MdImoveisExists(int id)
        {
            return _context.Imovel.Any(e => e.Id == id);
        }
    }
}
