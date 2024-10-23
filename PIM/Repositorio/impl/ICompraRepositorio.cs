using PIM.Models;

namespace PIM.Repositorio.impl
{
    public interface ICompraRepositorio
    {
        ComprasModel ListarPorId(int id);
        List<ComprasModel> BuscarTodos();
        ComprasModel Adicionar(ComprasModel comprasModel);

        ComprasModel Alterar(ComprasModel comprasModel);

        bool Apagar(int id);
    }
}
