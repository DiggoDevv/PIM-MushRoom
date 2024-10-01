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
            List<FornecedorModel> fonecedores = _fornecedorRepositorio.BuscarTodos();
            return View(fonecedores);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult Apagar(int id)
        {
            _fornecedorRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
        //recebendo a model
        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedorModel)
        {
            _fornecedorRepositorio.Adicionar(fornecedorModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(FornecedorModel fornecedorModel)
        {
            _fornecedorRepositorio.Alterar(fornecedorModel);
            return RedirectToAction("Index");
        }
    }
}
