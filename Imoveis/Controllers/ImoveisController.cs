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
        [BindProperty]
        public MdImoveis Imovel { get; set; }

        private readonly _DbContext _context;

        public ImoveisController(_DbContext context)
        {
            _context = context;
        }

        // GET: Imoveis
        public async Task<IActionResult> Index()
        {
            var _DbContext = _context.Imovel.Include(m => m.Usuario);
            return View(await _DbContext.Where(m => m.Usuario.Situacao == 0).ToListAsync());
        }

        // GET: Imoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new AgruparModels();
            model.oMdImoveis = DetailsImoveis(id);
            model.oMdImagens = ObterImagem(ViewBag.idImovel);

            if (model.oMdImoveis == null || model.oMdImoveis == null)
            {
                return NotFound();
            }

            return View(model);
        }

        MdImoveis DetailsImoveis(int? id)
        {
            var mdImoveis = _context.Imovel.Include(m => m.Usuario).FirstOrDefault(m => m.Id == id);
            ViewBag.idImovel = mdImoveis.Id;

            return (mdImoveis);
        }

        IEnumerable<MdImagens> ObterImagem(int? idImovel)
        {
            var imagens = _context.Imagem.Where(m => m.ImovelId == idImovel)
                .ToList();
            List<MdImagens> mdImagens = new List<MdImagens>();
            foreach (var img in imagens)
            {
                MdImagens Imag = new MdImagens()
                {
                    Id = img.Id,
                    Descricao = img.Descricao,
                    Dados = img.Dados,
                    ContentType = img.ContentType,
                    ImovelId = img.ImovelId
                };
                mdImagens.Add(Imag);
            }
            return (mdImagens);
        }
        public IActionResult VisualizarVariasImg(int id, int idImovel)
        {
            var imagensBanco = _context.Imagem.Where(m => m.ImovelId == idImovel).FirstOrDefault(a => a.Id == id);

            return File(imagensBanco.Dados, imagensBanco.ContentType);
        }

        // GET: Imoveis/Create
        public IActionResult Create()
        {
            ViewData["img"] = "~/img/imoveis/sem_imagem.jpg";
            ViewData["UsuarioId"] = new SelectList(_context.Usuario.Where(m => m.Situacao == 0), "Id", "Nome");
            return View();
        }

        // POST: Imoveis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnGetCreate(IList<IFormFile> imagens)
        {
            ModelState["Id"].Errors.Clear();
            ModelState.Remove("Id");

            Imovel.Situacao = 0;

            if (ModelState.IsValid)
            {
                _context.Add(Imovel);
                await _context.SaveChangesAsync();
            }

            foreach (IFormFile imagemCarregada in imagens)

                if (imagemCarregada != null)
                {
                    var img = Auxiliares.ResizeImg.ResizeImage(imagemCarregada);

                    MdImagens mdImagens = new MdImagens()
                    {
                        Descricao = imagemCarregada.FileName,
                        Dados = img.ToArray(),
                        ContentType = imagemCarregada.ContentType,
                        ImovelId = Imovel.Id

                    };
                    _context.Add(mdImagens);
                    _context.SaveChanges();
                }

            return RedirectToAction(nameof(Index));
        }

        // GET: Imoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var model = new AgruparModels();

            model.oMdImoveis = EditImovel(id);
            model.oMdImagens = ObterImagem(ViewBag.IdImovel);

            return View(model);


        }

        MdImoveis EditImovel(int? id)
        {
            var mdImoveis = _context.Imovel.Find(id);

            ViewBag.IdImovel = mdImoveis.Id;


            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome", mdImoveis.UsuarioId);
            return (mdImoveis);
        }

        // POST: Imoveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AgruparModels model)
        {
            var mdImovel = await _context.Imovel.Select(m => new { m.Id, m.UsuarioId }).FirstOrDefaultAsync(m => m.Id == id);

            model.oMdImoveis.UsuarioId = mdImovel.UsuarioId;

            if (id != model.oMdImoveis.Id)
            {
                return NotFound();
            }

            ModelState["Endereco"].Errors.Clear();
            ModelState.Remove("Endereco");

            ModelState["Descricao"].Errors.Clear();
            ModelState.Remove("Descricao");

            ModelState["oMdImagens"].Errors.Clear();
            ModelState.Remove("oMdImagens");

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(model.oMdImoveis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MdImoveisExists(model.oMdImoveis.Id))
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
            return View(model.oMdImoveis);
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

            return PartialView("_DeleteModalPartial", mdImoveis);
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

        public async Task<IActionResult> Block(int id)
        {
            var mdImoveis = await _context.Imovel.FindAsync(id);

            if (mdImoveis.Situacao == 0)
            {
                mdImoveis.Situacao = 1;
            }
            else if (mdImoveis.Situacao == 1)
            {
                mdImoveis.Situacao = 0;
            }
            if (ModelState.IsValid)
            {
                _context.Update(mdImoveis);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MdImoveisExists(int id)
        {
            return _context.Imovel.Any(e => e.Id == id);
        }
    }
}
