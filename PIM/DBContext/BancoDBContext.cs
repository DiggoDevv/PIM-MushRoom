﻿using Microsoft.EntityFrameworkCore;
using PIM.Models;

namespace PIM.DBContext
{
    //migrations vai pegar o conteudo(model) que está mapeaddo no context.
    public class BancoDBContext : DbContext
    {
        public BancoDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FornecedorModel> Fornecedores{ get; set; }  


    }
}
