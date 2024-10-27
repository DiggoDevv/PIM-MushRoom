using PIM.DBContext;
using PIM.Models;
using PIM.Repositorio.impl;

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
        public FornecedorModel ListarPorId(int id)
        {
            return _bancoDBContext.Fornecedores.FirstOrDefault(x => x.Id == id);
        }
        public List<FornecedorModel> BuscarTodos(int pagina = 1, int quantidadePorPagina = 5)
        {
            return _bancoDBContext.Fornecedores
                .Skip((pagina - 1) * quantidadePorPagina)
                .Take(quantidadePorPagina)
                .ToList();
        }
        public int ContarFornecedores()
        {
            return _bancoDBContext.Fornecedores.Count();
        }
        public FornecedorModel Alterar(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorDB = ListarPorId(fornecedor.Id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na atualização do fornecedor");

            fornecedorDB.Nome_fornecedor = fornecedor.Nome_fornecedor;
            fornecedorDB.Nome_produto = fornecedor.Nome_produto;
            fornecedorDB.Cnpj = fornecedor.Cnpj;
            fornecedorDB.Telefone = fornecedor.Telefone;

            _bancoDBContext.Fornecedores.Update(fornecedorDB);
            _bancoDBContext.SaveChanges();
            return fornecedorDB;
        }

        // gravar no banco de dados
        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            _bancoDBContext.Fornecedores.Add(fornecedor);
            _bancoDBContext.SaveChanges();
            return fornecedor;
        }
        public bool Apagar(int id)
        {
            FornecedorModel fornecedorDB = ListarPorId(id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na deleção do fornecedor");

            _bancoDBContext.Fornecedores.Remove(fornecedorDB);
            _bancoDBContext.SaveChanges();
            return true;
        }
    }
}
