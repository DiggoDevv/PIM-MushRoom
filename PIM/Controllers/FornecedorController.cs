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
            try
            {
                bool apagado = _fornecedorRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Fornecedor apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel apagar o contato do fornecedor";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel apagar o contato do fornecedor, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }


        }
        //recebendo a model
        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Adicionar(fornecedorModel);
                    TempData["MensagemSucesso"] = "Fornecedor cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(fornecedorModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o fornecedor, {erro.Message} tente novamente";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(FornecedorModel fornecedorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Alterar(fornecedorModel);
                    TempData["MensagemSucesso"] = "Fornecedor atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", fornecedorModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel atualizar o fornecedor, {erro.Message} tente novamente";
                return RedirectToAction("Index");
            }
        }
    }
}
