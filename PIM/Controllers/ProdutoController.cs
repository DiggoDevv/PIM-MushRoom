using Microsoft.AspNetCore.Mvc;
using PIM.Models;
using PIM.Repositorio;
using PIM.Repositorio.impl;

namespace PIM.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public IActionResult Index(int pagina = 1, int quantidadePorPagina = 5)
        {
            var produtos = _produtoRepositorio.BuscarTodos(pagina, quantidadePorPagina);
            var total = _produtoRepositorio.ContarProdutos();
            var totalPaginas = (int)Math.Ceiling((double)total / quantidadePorPagina);

            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.PaginaAtual = pagina;

            return View(produtos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _produtoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Produto apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel apagar o produto";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel apagar o produto, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }


        }
        //recebendo a model
        [HttpPost]
        public IActionResult Criar(ProdutoModel produtoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Adicionar(produtoModel);
                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(produtoModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o produto, {erro.Message} tente novamente";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ProdutoModel produtoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Alterar(produtoModel);
                    TempData["MensagemSucesso"] = "Produto atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", produtoModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel atualizar o produto, {erro.Message} tente novamente";
                return RedirectToAction("Index");
            }
        }
    }
}
