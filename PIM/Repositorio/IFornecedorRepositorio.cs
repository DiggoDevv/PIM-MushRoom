using PIM.Models;

namespace PIM.Repositorio
{
    public interface IFornecedorRepositorio
    {
        FornecedorModel ListarPorId(int id);
        List<FornecedorModel> BuscarTodos();
        FornecedorModel Adicionar(FornecedorModel fornecedor);

        FornecedorModel Alterar(FornecedorModel fornecedor);

        bool Apagar(int id);
    }
}
