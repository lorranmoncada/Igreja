using Igreja.Core;
using Igreja.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Igreja.Infraestructure
{
    public class IgrejaContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public IgrejaContext(IConfiguration configuration,DbContextOptions<IgrejaContext> options)
          : base(options) { _configuration = configuration; }

        public DbSet<Proprietario> Proprietario { get; set; }

        public DbSet<LoginProprietario> LoginProprietario { get; set; }

        public DbSet<IgrejaEntity> Igreja { get; set; }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<CategoriaIgreja> CategoriaIgreja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IgrejaContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var teste = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder
                .UseNpgsql(_configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());
        }

        //public async Task<bool> Commit()
        //{// ChangeTracker rastreia todas as entidades assim que é recuperada usando DbContext
        // // esta verificando todas as entidades que possuem a propriedade DataCadastro
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //        }
        //        // Se a entidade foi atualizada não sera atualizado o valor DataCadastro pois somente é para adicionar no momento de cadaastro da entidade no banco
        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCadastro").IsModified = false;
        //        }
        //    }

        //    // Se o número de linhas foi maior do que 0 é retornado true
        //    return await base.SaveChangesAsync() > 0;
        //}
    }
}
