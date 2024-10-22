using PIM.Models;

namespace PIM.Repositorio.impl
{
    public interface IProducaoRepositorio
    {
        ProducaoModel ListarPorId(int id);
        List<ProducaoModel> BuscarTodos();
        ProducaoModel Adicionar(ProducaoModel producao);

        ProducaoModel Alterar(ProducaoModel producao);

        bool Apagar(int id);
    }
}
