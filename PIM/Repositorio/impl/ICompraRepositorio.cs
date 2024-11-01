using PIM.Models;

namespace PIM.Repositorio.impl
{
    public interface ICompraRepositorio
    {
        ComprasModel ListarPorId(int id);
        List<ComprasModel> BuscarTodos(int pagina, int quantidadePagina);
        ComprasModel Adicionar(ComprasModel comprasModel);

        ComprasModel Alterar(ComprasModel comprasModel);

        public int ContarCompras();
        bool Apagar(int id);
    }
}
