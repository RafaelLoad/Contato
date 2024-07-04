using CadastroDeContatos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeContatos.Data.Context
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
        }

        public DbSet<Contato> Contato { get; set; }
        public DbSet<Ddd> Ddd { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        }
    }
}
