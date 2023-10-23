using Microsoft.EntityFrameworkCore;
using MorningStartApi.Data.Map;
using MorningStartApi.Models;

namespace MorningStartApi.Data
{
    public class SistemaMercadoriasDBContex : DbContext
    {
        public SistemaMercadoriasDBContex(DbContextOptions<SistemaMercadoriasDBContex> options)
            :base(options)
        {
        }

        public DbSet<MercadoriaModel> Mercadoria {  get; set; }
        public DbSet<EstoqueModel> Estoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MercadoriaMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());

            base.OnModelCreating(modelBuilder);
        }


    }
}
