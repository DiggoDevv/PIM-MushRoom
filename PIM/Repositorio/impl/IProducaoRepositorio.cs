using PIM.Models;

namespace PIM.Repositorio.impl
{
    public interface IProducaoRepositorio
    {
        ProducaoModel ListarPorId(int id);
        List<ProducaoModel> BuscarTodos(int pagina, int quantidadePagina);
        ProducaoModel Adicionar(ProducaoModel producao);

        ProducaoModel Alterar(ProducaoModel producao);

        public int ContarProducao();
        bool Apagar(int id);
    }
}
