using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {

            UsuarioService us = new UsuarioService();

            Usuario u  = new Usuario();

            u = null;

            u = us.ObterLogin(login,senha);

            if( u == null ){

                ViewData["Erro"] = "Usuário/Senha inválida";
                return View();
            }

            if( senha != u.Senha || login != u.Login)
            {
                ViewData["Erro"] = "Usuário/Senha inválida";
                return View();
            }
            else
            {
                    HttpContext.Session.SetString("user", login);
                    return RedirectToAction("Index");
            }
        }

         public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
