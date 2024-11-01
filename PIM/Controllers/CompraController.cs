using Microsoft.AspNetCore.Mvc;
using PIM.Models;
using PIM.Repositorio;
using PIM.Repositorio.impl;

namespace PIM.Controllers
{
    public class CompraController : Controller
    {
        private readonly ICompraRepositorio _compraRepositorio;
        public CompraController(ICompraRepositorio compraRepositorio)
        {
            _compraRepositorio = compraRepositorio;
        }
        public IActionResult Index(int pagina = 1, int quantidadePorPagina = 5)
        {
            var compras = _compraRepositorio.BuscarTodos(pagina, quantidadePorPagina);
            var total = _compraRepositorio.ContarCompras();
            var totalPaginas = (int)Math.Ceiling((double)total / quantidadePorPagina);

            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.PaginaAtual = pagina;

            return View(compras);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ComprasModel compras= _compraRepositorio.ListarPorId(id);
            return View(compras);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ComprasModel compras = _compraRepositorio.ListarPorId(id);
            return View(compras);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _compraRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Compra apagada com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel apagar a compra";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel apagar a compra, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }


        }
        //recebendo a model
        [HttpPost]
        public IActionResult Criar(ComprasModel compras)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _compraRepositorio.Adicionar(compras);
                    TempData["MensagemSucesso"] = "Compra cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(compras);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar a compra, {erro.Message} tente novamente";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ComprasModel compras)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _compraRepositorio.Alterar(compras);
                    TempData["MensagemSucesso"] = "Compra atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", compras);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel atualizar a compra, {erro.Message} tente novamente";
                return RedirectToAction("Index");
            }
        }
    }
}
