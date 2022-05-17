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

        public async Task<IActionResult> Index()
        {
            var _DbContext = _context.Imovel.Include(i => i.Usuario)
                .Where(i => i.Usuario.Situacao == 0 &&
                            i.Situacao == 0);
            return View(await _DbContext.ToListAsync());
        }

        public IActionResult VisualizarUmaImg(int id)
        {
            var imagemBanco = _context.Imagem.FirstOrDefault(a => a.ImovelId == id);

            return File(imagemBanco.Dados, imagemBanco.ContentType);
        }

        public async Task<IActionResult> VisualizarVariasImg(int id)
        {
            var Imagem = await _context.Imagem.Where(m => m.ImovelId == id).ToListAsync();

            foreach(var img in Imagem)
            {
                ViewBag["Imagens"] = File(img.Dados, img.ContentType);
            }
            
            return View(ViewBag.Imagens);
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