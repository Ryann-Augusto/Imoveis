using Imoveis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Imoveis.Controllers
{
    public class HomeController : Controller
    {
        private readonly _DbContext _context;

        public HomeController(_DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index([FromQuery(Name ="b")] string termoBusca, [FromQuery(Name = "o")]int ordem)
        {
            var query = _context.Imovel.Include(u => u.Usuario)
                    .Where(i => i.Usuario.Situacao == 0 && i.Situacao == 0).OrderByDescending(i => i.Id).AsQueryable();


            if (!string.IsNullOrEmpty(termoBusca))
            {
                query = query.Where(i => i.Endereco.Cidade.ToUpper().Contains(termoBusca.ToUpper()) 
                        || i.Descricao.ToUpper().Contains(termoBusca.ToUpper()));

                ViewData["busca"] = termoBusca;
            }
            
            if(ordem != 0)
            {
                
                switch(ordem)
                {
                    case 1:
                        query = query.OrderBy(i => i.Descricao);
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

            return View(await query.ToListAsync());
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

        public async Task<IActionResult> VisualizarVariasImg(int id)
        {
            var Imagem = await _context.Imagem.Where(m => m.ImovelId == id).ToListAsync();

            foreach (var img in Imagem)
            {
                ViewBag["Imagens"] = File(img.Dados, img.ContentType);
            }

            return View(ViewBag.Imagens);
        }

        public async Task Busca()
        {
            var BuscarImoveis = await _context.Imovel.ToListAsync();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}