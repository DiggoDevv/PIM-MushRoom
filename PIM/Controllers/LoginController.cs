using Microsoft.AspNetCore.Mvc;
using PIM.Models;
using PIM.Repositorio.impl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PIM.Controllers
{
    public class LoginController : Controller
    {
        private readonly IloginRepositorio _loginRepositorio;
        public LoginController(IloginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoginModel login = _loginRepositorio.BuscarPorLogin(loginModel.Login);

                    if (login != null)
                    {
                        if (login.SenhaValida(loginModel.Senha))
                        {

                            return RedirectToAction("index", "home");
                        }
                    }
                    TempData["MensagemErro"] = "Usuário e/ou senha inválida tente novamente";

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel realizar o login, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
