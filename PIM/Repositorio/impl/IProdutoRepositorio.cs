using PIM.Models;

namespace PIM.Repositorio.impl
{
    public interface IProdutoRepositorio
    {
        ProdutoModel ListarPorId(int id);
        List<ProdutoModel> BuscarTodos(int pagina, int quantidadePagina);
        ProdutoModel Adicionar(ProdutoModel produto);
        ProdutoModel Alterar(ProdutoModel produto);

        public int ContarProdutos();
        bool Apagar(int id);
    }
}
