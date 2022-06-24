#nullable disable
using Imoveis.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Imoveis.Controllers
{
    [AllowAnonymous]
    public class ContaController : Controller
    {

        private readonly _DbContext _context;
        private readonly IHttpContextAccessor _httpContextAcessor;

        public ContaController(_DbContext context, IHttpContextAccessor httpContextAcessor)
        {
            _context = context;
            _httpContextAcessor = httpContextAcessor;
        }

        [BindProperty]
        public DadosLogin Dados { get; set; }

        [TempData]
        public string ReturnUrl { get; set; }

        [TempData]
        public string MensagemDeErro { get; set; }

        public async Task<IActionResult> Login(string returnUrl, bool erroLogin)
        {
            if (erroLogin)
            {
                TempData["erro"] = "Usuario ou senha incorreto.";
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            ReturnUrl = returnUrl;

            return View();
        }

        public async Task<IActionResult> Entrar(string returnUrl)
        {
            returnUrl = ReturnUrl ?? Url.Content("~/");

            var Usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == Dados.Email);

            if (Usuario == null)
            {
                return RedirectToAction(nameof(Login), new { erroLogin = true });
            }

            if (!Usuario.Email.Equals(Dados.Email) ||
                !Usuario.Senha.Equals(Dados.Senha))
            {
                return RedirectToAction(nameof(Login), new { erroLogin = true });
            }
            else
            {
                await Autenticar(Usuario.Id.ToString(), Usuario.Nome, Usuario.Nivel.ToString());
                return LocalRedirect(returnUrl);
            }
        }

        public async Task<IActionResult> Sair()
        {
            await Logout();
            return RedirectToAction(nameof(Login), "Conta");
        }

        public async Task Autenticar(string Id, string Nome, string Nivel)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Sid, Id));
            claims.Add(new Claim(ClaimTypes.Name, Nome));
            claims.Add(new Claim(ClaimTypes.Email, Dados.Email));
            claims.Add(new Claim(ClaimTypes.Role, Nivel));

            var claimsIdentity =
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme
                        )
                    );

            var authProperties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTime.Now.AddHours(8),
                IssuedUtc = DateTime.Now
            };

            await _httpContextAcessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
        }

        public async Task Logout()
        {
            await _httpContextAcessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
