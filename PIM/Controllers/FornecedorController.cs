using Microsoft.AspNetCore.Mvc;
using PIM.Models;
using PIM.Repositorio.impl;

namespace PIM.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }
        public IActionResult Index(int pagina = 1, int quantidadePorPagina = 5)
        {
            var fornecedores = _fornecedorRepositorio.BuscarTodos(pagina, quantidadePorPagina);
            var total = _fornecedorRepositorio.ContarFornecedores();
            var totalPaginas = (int)Math.Ceiling((double)total / quantidadePorPagina);

            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.PaginaAtual = pagina;

            return View(fornecedores);
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
                    return RedirectToAction("Index"); // Redireciona para a Index após sucesso
                }

                TempData["MensagemErro"] = "Houve um problema com o cadastro. Verifique os dados informados.";
                return RedirectToAction("Index"); // Redireciona para a Index em caso de erro de validação
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o fornecedor. Detalhes: {erro.Message}";
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
