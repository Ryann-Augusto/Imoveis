#nullable disable
using Imoveis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

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

        public async Task<IActionResult> Index([FromQuery(Name = "b")] string termoBusca, [FromQuery(Name = "o")] int? ordem,
            [FromQuery(Name = "p")] int? pagina = 1, [FromQuery(Name = "t")] int tamanhoPagina = 20)
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
                        query = query.OrderByDescending(i => i.Descricao.ToUpper());
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
            ViewBag.QuantidadePaginas = Convert.ToInt32(Math.Ceiling(qtdImovel * 1M / tamanhoPagina));

            query = query.Skip(tamanhoPagina * (this.PaginaAtual - 1)).Take(tamanhoPagina);

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

        public async Task<IActionResult> Imagem(int id)
        {

            var imagensBanco = await _context.Imagem.FirstOrDefaultAsync(a => a.ImovelId == id);
            if (imagensBanco == null)
            {
                var filePath = "~/img/imoveis/sem_imagem.jpg";

                return File(filePath, "image/jpeg");
            }
            else
            {
                return File(imagensBanco.Dados, imagensBanco.ContentType);
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

        public async Task<IActionResult> VisualizarVariasImg(int id, int idImovel)
        {
            var imagensBanco = await _context.Imagem.Where(m => m.ImovelId == idImovel).FirstOrDefaultAsync(a => a.Id == id);

            if (imagensBanco == null)
            {
                var filePath = "~/img/imoveis/sem_imagem.jpg";

                return File(filePath, "image/jpeg");

            }
            else
            {
                return File(imagensBanco.Dados, imagensBanco.ContentType);
            }
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

        public async Task<IActionResult> SendContact([FromQuery(Name = "Nome")] string Nome, [FromQuery(Name = "Email")] string Email,
            [FromQuery(Name = "Telefone")] string Telefone, [FromQuery(Name = "Mensagem")] string Mensagem)
        {
            string urlAnterior = Request.Headers["Referer"].ToString();

            var UrlDividida = urlAnterior.Split("/");

            if (Nome == null || Email == null || Mensagem == null)
            {
                ViewData["message"] = "Informações inválidas";
                return RedirectToRoute(new { controller = "Home", action = "Visualizar", id = UrlDividida[5] });
            }
            else
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress("joaopereira131516@gmail.com")
                };
                mail.To.Add(new MailAddress("ryann.cruz97@gmail.com"));

                mail.Subject = "Contato de " + Email + " Leon Imóveis";
                mail.Body = "<p>Nome: " + Nome + "</p>" +
                            "<p>Email: " + Email + "</p>";
                if (!String.IsNullOrEmpty(Telefone))
                    mail.Body += "<p>Telefone: " + Telefone + "</p>";
                mail.Body += "<p>Mensagem: " + Mensagem + "</p>";
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                try
                {
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("joaopereira131516@gmail.com", "vkdrsuloismvrgsx");
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mail);
                    }
                }
                catch (Exception ex)
                {
                    ViewData["message"] = "Falha ao enviar " + ex;
                }

                return RedirectToRoute(new { controller = "Home", action = "Visualizar", id = UrlDividida[5] });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}