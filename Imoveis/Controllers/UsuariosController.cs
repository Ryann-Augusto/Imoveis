#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Imoveis.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;

namespace Imoveis.Controllers
{
    [Authorize(Policy = "Admin")]
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
            return View(await _context.Usuario.OrderByDescending(u => u.Id).ToListAsync());
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,ConfirmSenha,Cpf_Cnpj,Telefone,Nivel")] MdUsuarios mdUsuarios)
        {
            var contcpf = mdUsuarios.Cpf_Cnpj.Trim().Length;
            var conttelefone = mdUsuarios.Telefone.Trim().Length;

            if (contcpf != 11 && contcpf != 14)
            {
                ModelState.AddModelError("Cpf_Cnpj", "Os valores do CPF ou CNPJ não são válidos!");
            }

            if (conttelefone != 11)
            {
                ModelState.AddModelError("Telefone", "O Número informado não é válido ele deve conter 11 caracteres!");
            }

            Auxiliares.Hash hash = new(SHA256.Create());
            mdUsuarios.Senha = hash.CriptografarSenha(mdUsuarios.Senha);

            mdUsuarios.Situacao = 0;

            if (ModelState.IsValid)
            {
                _context.Add(mdUsuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mdUsuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mdUsuarios = await _context.Usuario.FindAsync(id);
            mdUsuarios.Senha = String.Empty;
            mdUsuarios.ConfirmSenha = String.Empty;

            if (mdUsuarios == null)
            {
                return NotFound();
            }
            return View(mdUsuarios);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Cpf,Senha,ConfirmSenha,Telefone,Nivel")] MdUsuarios mdUsuarios)
        {

            if (id != mdUsuarios.Id)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuario.Select(m => new { m.Id, m.Cpf_Cnpj, m.Senha }).FirstOrDefaultAsync(m => m.Id == id);

            mdUsuarios.Cpf_Cnpj = usuarios.Cpf_Cnpj;

            ModelState["Cpf_Cnpj"].Errors.Clear();
            ModelState.Remove("Cpf_Cnpj");

            if (mdUsuarios.Senha != mdUsuarios.ConfirmSenha)
            {
                ModelState.AddModelError("ConfirmSenha", "A confirmação de senha não confere com a senha informada.");
            }

            if (!string.IsNullOrEmpty(mdUsuarios.Senha))
            {
                Auxiliares.Hash hash = new(SHA256.Create());
                mdUsuarios.Senha = hash.CriptografarSenha(mdUsuarios.Senha);
            }
            else
            {
                mdUsuarios.Senha = usuarios.Senha;
                ModelState["Senha"].Errors.Clear();
                ModelState.Remove("Senha");

                ModelState["ConfirmSenha"].Errors.Clear();
                ModelState.Remove("ConfirmSenha");
            }

            if (ModelState.IsValid)
            {
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
                        return RedirectToAction("Index", "Usuario");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mdUsuarios);
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

            return PartialView("_DeleteModalPartial", mdUsuarios);
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

        public async Task<IActionResult> Block(int id)
        {
            var mdUsuario = await _context.Usuario.FindAsync(id);

            if (mdUsuario.Situacao == 0)
            {
                mdUsuario.Situacao = 1;
            }
            else if (mdUsuario.Situacao == 1)
            {
                mdUsuario.Situacao = 0;
            }

            if (ModelState.IsValid)
            {
                _context.Update(mdUsuario);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        private bool MdUsuariosExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
