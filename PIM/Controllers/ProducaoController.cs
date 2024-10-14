using Microsoft.AspNetCore.Mvc;
using PIM.Models;
using PIM.Repositorio;

namespace PIM.Controllers
{
    public class ProducaoController : Controller
    {
        private readonly IProducaoRepositorio _producaoRepositorio;
        public ProducaoController(IProducaoRepositorio producaoRepositorio)
        {
            _producaoRepositorio = producaoRepositorio;
        }

        public IActionResult Index()
        {
            List<ProducaoModel> producoes= _producaoRepositorio.BuscarTodos();
            return View(producoes);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ProducaoModel producao = _producaoRepositorio.ListarPorId(id);
            return View(producao);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ProducaoModel producao = _producaoRepositorio.ListarPorId(id);
            return View(producao);
        }

        [HttpPost]
        public IActionResult Criar(ProducaoModel producaoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _producaoRepositorio.Adicionar(producaoModel);
                    TempData["MensagemSucesso"] = "Produção cadastrada com sucesso";
                    return RedirectToAction("Index");
                }
                return View(producaoModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar a produção, {erro.Message} tente novamente";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _producaoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Produção apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel apagar a produção";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel apagar a produção, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(ProducaoModel producaoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _producaoRepositorio.Alterar(producaoModel);
                    TempData["MensagemSucesso"] = "Produção atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", producaoModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel atualizar a produção, {erro.Message} tente novamente";
                return RedirectToAction("Index");
            }
        }
    }
}
