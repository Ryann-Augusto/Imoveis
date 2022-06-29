#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Imoveis.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Imoveis.Controllers
{
    [Authorize(Policy = "User")]
    public class ImoveisController : Controller
    {
        [BindProperty]
        public MdImoveis Imovel { get; set; }

        private readonly _DbContext _context;
        private readonly IHttpContextAccessor _httpContextAcessor;

        public ImoveisController(_DbContext context, IHttpContextAccessor httpContextAcessor)
        {
            _context = context;
            _httpContextAcessor = httpContextAcessor;
        }

        // GET: Imoveis
        public async Task<IActionResult> Index()
        {
            var UserId = _httpContextAcessor.HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value;
            var _DbContext = _context.Imovel.Include(i => i.Usuario).Where(i => i.UsuarioId == Convert.ToInt32(UserId)).OrderByDescending(i => i.Id);
            var imovel = await _DbContext.ToListAsync();
            return View(imovel);
        }

        // GET: Imoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new AgruparModels();
            model.oMdImoveis = await DetailsImoveis(id);
            model.oMdImagens = await ObterImagem(ViewBag.idImovel);

            if (model.oMdImoveis == null || model.oMdImoveis == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public async Task<MdImoveis> DetailsImoveis(int? id)
        {
            var mdImoveis = await _context.Imovel.Include(m => m.Usuario).FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.idImovel = mdImoveis.Id;

            return (mdImoveis);
        }

        public async Task<IEnumerable<MdImagens>> ObterImagem(int? idImovel)
        {
            var imagens = await _context.Imagem.Where(m => m.ImovelId == idImovel)
                .ToListAsync();
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

        public async Task<IActionResult> VisualizarVariasImg(int id, int idImovel)
        {
            var imagensBanco = await _context.Imagem.Where(m => m.ImovelId == idImovel).FirstOrDefaultAsync(a => a.Id == id);

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
            try
            {
                var UserId = _httpContextAcessor.HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value;
                ModelState["Id"].Errors.Clear();
                ModelState.Remove("Id");

                Imovel.Situacao = 0;
                Imovel.UsuarioId = Convert.ToInt32(UserId);

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
                        await _context.SaveChangesAsync();
                        TempData["sucesso"] = "Imovel adicionado com sucesso!";
                    }
            }
            catch
            {
                TempData["erro"] = "Não foi possível adicionar este imovel!";
            }
            

            return RedirectToAction(nameof(Index));
        }

        // GET: Imoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var model = new AgruparModels();
            var UserId = _httpContextAcessor.HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value;

            model.oMdImoveis = await EditImovel(id);

            if (model.oMdImoveis.UsuarioId != Convert.ToInt32(UserId))
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            model.oMdImagens = await ObterImagem(ViewBag.IdImovel);

            return View(model);
        }

        public async Task<MdImoveis> EditImovel(int? id)
        {
            var mdImoveis = await _context.Imovel.FindAsync(id);

            ViewBag.IdImovel = mdImoveis.Id;

            //SELECIONAR UMA LISTA DO BANCO DE DADOS
            //ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nome", mdImoveis.UsuarioId);
            return (mdImoveis);
        }

        // POST: Imoveis/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IList<IFormFile> imagens, AgruparModels model)
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

            ModelState["Nome"].Errors.Clear();
            ModelState.Remove("Nome");

            ModelState["oMdImagens"].Errors.Clear();
            ModelState.Remove("oMdImagens");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model.oMdImoveis);
                    await _context.SaveChangesAsync();

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
                            await _context.SaveChangesAsync();
                            TempData["sucesso"] = "Imovel alterado com sucesso!";
                        }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MdImoveisExists(model.oMdImoveis.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["erro"] = "Não foi possível alterar este imovel!";
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
            try
            {
                var mdImoveis = await _context.Imovel.FindAsync(id);
                _context.Imovel.Remove(mdImoveis);
                await _context.SaveChangesAsync();
                TempData["sucesso"] = "Imovel excluido com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["erro"] = "Não foi possível excluir este imovel!";
                throw;
            }
            
        }

        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mdImages = await _context.Imagem
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mdImages == null)
            {
                return NotFound();
            }

            return PartialView("_DeleteImagePartial", mdImages);
        }

        [HttpPost, ActionName("DeleteImage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteImgConfirmad(int id)
        {
            if (id != 0)
            {
                try
                {
                    var mdImagens = await _context.Imagem.FindAsync(id);
                    _context.Imagem.Remove(mdImagens);
                    await _context.SaveChangesAsync();
                    TempData["sucesso"] = "Imagem excluida com sucesso!";
                    return RedirectToAction(nameof(Edit), new { id = mdImagens.ImovelId });
                }
                catch
                {
                    TempData["erro"] = "Não foi possivel excluir a imagem!";
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
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
