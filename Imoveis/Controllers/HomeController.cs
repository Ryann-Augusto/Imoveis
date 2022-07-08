#nullable disable
using Imoveis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Imoveis.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly _DbContext _context;

        public HomeController(_DbContext context)
        {
            _context = context;
        }

        public int PaginaAtual { get; set; }

        public async Task<IActionResult> Index([FromQuery(Name = "b")] string termoBusca, [FromQuery(Name = "o")]int? ordem,
            [FromQuery(Name ="p")] int? pagina = 1, [FromQuery(Name = "t")] int tamanhoPagina = 20)
        {
            this.PaginaAtual = pagina.Value;
            ViewBag.PaginaAtual = pagina.Value;

            var query = _context.Imovel.Include(u => u.Usuario)
                    .Where(i => i.Usuario.Situacao == 0 && i.Situacao == 0).AsQueryable();

            if (!string.IsNullOrEmpty(termoBusca))
            {
                query = query.Where(i => i.Endereco.Cidade.ToUpper().Contains(termoBusca.ToUpper())
                        || i.Nome.ToUpper().Contains(termoBusca.ToUpper()));

                ViewData["busca"] = termoBusca;
            }

            if (ordem == 0)
            {
                query = query.OrderByDescending(i => i.Id).AsQueryable();
            }
            else
            {
                switch (ordem)
                {
                    case 1:
                        query = query.OrderBy(i => i.Descricao.ToUpper());
                        break;
                    case 2:
                        query = query.OrderBy(i => i.Valor);
                        break;
                    case 3:
                        query = query.OrderByDescending(i => i.Valor);
                        break;
                    case 4:
                        query = query.OrderBy(i => i.Quarto);
                        break;
                    case 5:
                        query = query.OrderByDescending(i => i.Quarto);
                        break;
                }
            }

            var queryCount = query;
            int qtdImovel = queryCount.Count();
            ViewBag.QuantidadePaginas = Convert.ToInt32(Math.Ceiling(qtdImovel*1M / tamanhoPagina));

            query = query.Skip(tamanhoPagina * (this.PaginaAtual -1 )).Take(tamanhoPagina);

            return View(await query.ToListAsync());
        }

        public async Task<IEnumerable<MdImagens>> ObterImagem(int? idImovel)
        {
            var imagens = await _context.Imagem.Where(m => m.ImovelId == idImovel)
                .ToListAsync();
            List<MdImagens> mdImagens = new();
            foreach (var img in imagens)
            {
                MdImagens Imag = new()
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

        public IActionResult VisualizarUmaImg(int id)
        {
            var imagemBanco = _context.Imagem.FirstOrDefault(a => a.ImovelId == id);

            if (imagemBanco == null)
            {
                var filePath = "~/img/imoveis/sem_imagem.jpg";

                return File(filePath, "image/jpeg");

            }
            else
            {
                return File(imagemBanco.Dados, imagemBanco.ContentType);
            }

        }

        public async Task<IActionResult> VisualizarVariasImg(int id, int idImovel)
        {
            var imagensBanco = await _context.Imagem.Where(m => m.ImovelId == idImovel).FirstOrDefaultAsync(a => a.Id == id);

            return File(imagensBanco.Dados, imagensBanco.ContentType);
        }

        public async Task<IActionResult> RecuperarImagem(int id)
        {

            ViewBag.idImovel = id;

            var imagens = await _context.Imagem.Where(m => m.ImovelId == id)
                .ToListAsync();
            List<MdImagens> mdImagens = new();
            foreach (var img in imagens)
            {
                MdImagens Imag = new()
                {
                    Id = img.Id,
                    Descricao = img.Descricao,
                    Dados = img.Dados,
                    ContentType = img.ContentType,
                    ImovelId = img.ImovelId
                };
                mdImagens.Add(Imag);
            }
            return PartialView("_VisualizarImagensModalPartial", mdImagens);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Visualizar(int id)
        {
            var models = new AgruparModels
            {
                oMdImoveis = await _context.Imovel.Include(u => u.Usuario).FirstOrDefaultAsync(i => i.Id == id)
            };

            ViewBag.idImovel = models.oMdImoveis.Id;

            models.oMdImagens = await ObterImagem(ViewBag.idImovel);

            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}