using PIM.Models;

namespace PIM.Repositorio.impl
{
    public interface IProdutoRepositorio
    {
        ProdutoModel ListarPorId(int id);
        List<ProdutoModel> BuscarTodos();
        ProdutoModel Adicionar(ProdutoModel produto);
        ProdutoModel Alterar(ProdutoModel produto);
        bool Apagar(int id);
    }
}
