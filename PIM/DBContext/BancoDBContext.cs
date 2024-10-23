using Microsoft.EntityFrameworkCore;
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
        public DbSet<ProducaoModel> Producao { get; set; }
        public DbSet<LoginModel> Login { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<ComprasModel> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComprasModel>()
                .Property(c => c.Valor_total)
                .HasColumnType("decimal(10,2)"); // Definir a precisão e escala

            base.OnModelCreating(modelBuilder);
        }
    }
}
