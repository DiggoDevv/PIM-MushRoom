using PIM.Models;

namespace PIM.Repositorio.impl
{
    public interface IFornecedorRepositorio
    {
        FornecedorModel ListarPorId(int id);
        List<FornecedorModel> BuscarTodos(int pagina, int quantidadePagina);
        FornecedorModel Adicionar(FornecedorModel fornecedor);

        FornecedorModel Alterar(FornecedorModel fornecedor);
        public int ContarFornecedores();
        bool Apagar(int id);
    }
}
