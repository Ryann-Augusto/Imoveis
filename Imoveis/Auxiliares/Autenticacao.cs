using Imoveis.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Imoveis.Auxiliares
{
    public class Autenticacao
    {
        public async Task Login(HttpContext context, DadosLogin Dados, string Nivel)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, Dados.Email));
            claims.Add(new Claim(ClaimTypes.Role, Nivel.ToString()));

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

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
        }

        public async Task Logout(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}