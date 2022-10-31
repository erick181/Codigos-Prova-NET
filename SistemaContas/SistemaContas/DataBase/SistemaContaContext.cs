using Microsoft.EntityFrameworkCore;
using SistemaContas.DataBase.Map;
using SistemaContas.Models;

namespace SistemaContas.DataBase
{
    public class SistemaContaContext : DbContext
    {

        public SistemaContaContext(DbContextOptions<SistemaContaContext> options) : base(options)   
        {

        }

        public DbSet<ContaModel> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ContaMap());
            base.OnModelCreating(modelBuilder); 
        }




    }
}
