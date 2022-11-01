using Cineminha.Aplicacao.Interfaces;
using Cineminha.Apresentacao.Mvc.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cineminha.Apresentacao.Mvc.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public AuthenticationController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        public IActionResult LoginExecute()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginExecute(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var cipherPassword = _usuarioAplicacao.EncryptPassword(loginViewModel.Senha);
                var usuario = _usuarioAplicacao.Procurar(c => c.Login == loginViewModel.Login && c.Senha == cipherPassword).FirstOrDefault();

                if (usuario == null)
                {
                    ModelState.AddModelError("", "Usuário e/ou Senha incorretos!");
                    return View("LoginExecute");
                }
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, usuario.Nome));
                claims.Add(new Claim(ClaimTypes.Role, usuario.Funcao));

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                              new ClaimsPrincipal(identity),
                                              new AuthenticationProperties
                                              {
                                                  IsPersistent = false   //remember me
                                              });

                return Redirect("~/Home/Index");
            }
            return View("LoginExecute");
        }

        public async Task<IActionResult> LogoutExecute()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LoginExecute");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}