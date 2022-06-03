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

        public async Task<IActionResult> Index([FromQuery] string termoBusca)
        {
            if (string.IsNullOrEmpty(termoBusca))
            {
                var _dbContext = _context.Imovel.Include(i => i.Usuario)
                .Where(i => i.Usuario.Situacao == 0 &&
                            i.Situacao == 0).ToListAsync();

                return View(await _dbContext);
            }
            else
            {
                var _dbContext = _context.Imovel.Where(
                    i => i.Descricao.ToUpper().Contains(termoBusca.ToUpper())).ToListAsync();

                ViewData["busca"] = termoBusca;

                return View(await _dbContext);
            }

            
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