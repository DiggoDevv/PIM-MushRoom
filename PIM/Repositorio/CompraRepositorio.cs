using PIM.DBContext;
using PIM.Models;
using PIM.Repositorio.impl;

namespace PIM.Repositorio
{
    public class CompraRepositorio : ICompraRepositorio
    {
        //context vai gravar no banco de dados
        private readonly BancoDBContext _bancoDBContext;
        public CompraRepositorio(BancoDBContext bancoDBContext) 
        {
            _bancoDBContext = bancoDBContext;            
        }
        public ComprasModel ListarPorId(int id)
        {
            return _bancoDBContext.Compras.FirstOrDefault(x => x.Id == id);
        }
        public List<ComprasModel> BuscarTodos(int pagina = 1, int quantidadePorPagina = 5)
        {
            return _bancoDBContext.Compras
                .Skip((pagina - 1) * quantidadePorPagina)
                .Take(quantidadePorPagina)
                .ToList();
        }
        public int ContarCompras()
        {
            return _bancoDBContext.Compras.Count();
        }
        public ComprasModel Alterar(ComprasModel compras)
        {
            ComprasModel comprasDB = ListarPorId(compras.Id);

            if (comprasDB == null) throw new System.Exception("Houve um erro na atualização da compra");

            comprasDB.Nome_fornecedor = compras.Nome_fornecedor;
            comprasDB.Produto_comprado = compras.Produto_comprado;
            comprasDB.Qtd_comprada = compras.Qtd_comprada;
            comprasDB.Valor_total = compras.Valor_total;

            _bancoDBContext.Compras.Update(comprasDB);
            _bancoDBContext.SaveChanges();
            return comprasDB;
        }

        // gravar no banco de dados
        public ComprasModel Adicionar(ComprasModel compras)
        {
            _bancoDBContext.Compras.Add(compras);
            _bancoDBContext.SaveChanges();
            return compras;
        }
        public bool Apagar(int id)
        {
            ComprasModel comprasDB = ListarPorId(id);

            if (comprasDB == null) throw new System.Exception("Houve um erro na deleção da compra");

            _bancoDBContext.Compras.Remove(comprasDB);
            _bancoDBContext.SaveChanges();
            return true;
        }

       
    }
}
