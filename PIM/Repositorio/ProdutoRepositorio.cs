using PIM.DBContext;
using PIM.Models;
using PIM.Repositorio.impl;

namespace PIM.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        //context vai gravar no banco de dados
        private readonly BancoDBContext _bancoDBContext;
        public ProdutoRepositorio(BancoDBContext bancoDBContext) 
        {
            _bancoDBContext = bancoDBContext;            
        }
        public ProdutoModel ListarPorId(int id)
        {
            return _bancoDBContext.Produto.FirstOrDefault(x => x.Id == id);
        }
        public List<ProdutoModel> BuscarTodos(int pagina = 1, int quantidadePorPagina = 5)
        {
            return _bancoDBContext.Produto
                .Skip((pagina - 1) * quantidadePorPagina)
                .Take(quantidadePorPagina)
                .ToList();
        }

        public ProdutoModel Alterar(ProdutoModel produto)
        {
            ProdutoModel produtoDB = ListarPorId(produto.Id);

            if (produtoDB == null) throw new System.Exception("Houve um erro na atualização do fornecedor");

            produtoDB.Nome_Produto = produto.Nome_Produto;
            produtoDB.Info_Produto = produto.Info_Produto;
            produtoDB.Quant_minima = produto.Quant_minima;
            produtoDB.Quant_estoque = produto.Quant_estoque;

            _bancoDBContext.Produto.Update(produtoDB);
            _bancoDBContext.SaveChanges();
            return produtoDB;
        }

        // gravar no banco de dados
        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            _bancoDBContext.Produto.Add(produto);
            _bancoDBContext.SaveChanges();
            return produto;
        }
        public bool Apagar(int id)
        {
            ProdutoModel produtoDB= ListarPorId(id);

            if (produtoDB == null) throw new System.Exception("Houve um erro na deleção do produto");

            _bancoDBContext.Produto.Remove(produtoDB);
            _bancoDBContext.SaveChanges();
            return true;
        }
        public int ContarProdutos()
        {
            return _bancoDBContext.Produto.Count();
        }
    }
}
