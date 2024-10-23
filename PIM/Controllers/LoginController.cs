using Microsoft.AspNetCore.Mvc;
using PIM.Helper;
using PIM.Models;
using PIM.Repositorio.impl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PIM.Controllers
{
    public class LoginController : Controller
    {
        private readonly IloginRepositorio _loginRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IloginRepositorio loginRepositorio, ISessao sessao)
        {
            _loginRepositorio = loginRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            // Se o usuario estiver logado, redirecionar para a home
            if(_sessao.BuscarSessaoLogin() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoLogin();

            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoLogin(login);
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
