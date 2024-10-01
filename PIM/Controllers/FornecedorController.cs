using Microsoft.AspNetCore.Mvc;
using PIM.Models;
using PIM.Repositorio;

namespace PIM.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        //recebendo a model
        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedorModel)
        {
            _fornecedorRepositorio.Adicionar(fornecedorModel);
            return RedirectToAction("Index");
        }
    }
}
