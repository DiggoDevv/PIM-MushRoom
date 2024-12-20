﻿using PIM.DBContext;
using PIM.Models;
using PIM.Repositorio.impl;

namespace PIM.Repositorio
{
    public class ProducaoRepositorio : IProducaoRepositorio
    {
        //context vai gravar no banco de dados
        private readonly BancoDBContext _bancoDBContext;
        public ProducaoRepositorio(BancoDBContext bancoDBContext)
        {
            _bancoDBContext = bancoDBContext;
        }
        public ProducaoModel ListarPorId(int id)
        {
            return _bancoDBContext.Producao.FirstOrDefault(x => x.Id == id);
        }
        public List<ProducaoModel> BuscarTodos(int pagina = 1, int quantidadePorPagina = 5)
        {
            return _bancoDBContext.Producao
                .Skip((pagina - 1) * quantidadePorPagina)
                .Take(quantidadePorPagina)
                .ToList();
        }
        public int ContarProducao()
        {
            return _bancoDBContext.Producao.Count();
        }

        public ProducaoModel Alterar(ProducaoModel producao)
        {
            ProducaoModel producaodb = ListarPorId(producao.Id);

            if (producaodb == null) throw new System.Exception("Houve um erro na atualização da producao");

            producaodb.Nome_producao = producao.Nome_producao;
            producaodb.Info_producao = producao.Info_producao;
            producaodb.Ini_producao = producao.Ini_producao;
            producaodb.Troca_substrato = producao.Troca_substrato;

            _bancoDBContext.Producao.Update(producaodb);
            _bancoDBContext.SaveChanges();
            return producaodb;
        }

        // gravar no banco de dados
        public ProducaoModel Adicionar(ProducaoModel producao)
        {
            _bancoDBContext.Producao.Add(producao);
            _bancoDBContext.SaveChanges();
            return producao;
        }
        public bool Apagar(int id)
        {
            ProducaoModel producaodb = ListarPorId(id);

            if (producaodb == null) throw new System.Exception("Houve um erro na deleção da producao");

            _bancoDBContext.Producao.Remove(producaodb);
            _bancoDBContext.SaveChanges();
            return true;
        }
    }
}
