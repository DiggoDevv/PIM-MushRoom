using PIM.DBContext;
using PIM.Models;

namespace PIM.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        //context vai gravar no banco de dados
        private readonly BancoDBContext _bancoDBContext;
        public FornecedorRepositorio(BancoDBContext bancoDBContext) 
        {
            _bancoDBContext = bancoDBContext;            
        }

        // gravar no banco de dados
        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            _bancoDBContext.Fornecedores.Add(fornecedor);
            _bancoDBContext.SaveChanges();
            return fornecedor;
        }
    }
}
