using Igreja.Fieis.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Ingreja.Fieis.Infraestructure
{
    public class FielContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public FielContext(IConfiguration configuration, DbContextOptions<FielContext> options)
          : base(options) { _configuration = configuration; }

        public DbSet<LoginFiel> LoginFiel { get; set; }
        public DbSet<Fiel> Fiel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FielContext).Assembly);
        }

    }
}
