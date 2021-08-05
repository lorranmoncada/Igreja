using Igreja.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure.Mapping
{
    public class LoginProprietarioMap : IEntityTypeConfiguration<LoginProprietario>
    {
        public void Configure(EntityTypeBuilder<LoginProprietario> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("id_user_proprietario");
            builder.Property(l => l.Login).IsRequired().HasColumnName("login").HasMaxLength(50);
            builder.Property(l => l.DataCadastro).IsRequired().HasColumnName("data_cadastro");
            builder.Property(l => l.Senha).IsRequired().HasColumnName("senha").HasMaxLength(10);
            
            // Relacionamento 1 : 1 | Proprietario : LoginProprietario 
            builder.HasOne(l => l.Proprietario).WithOne(l => l.LoginProprietario).HasForeignKey<Proprietario>(fk => fk.IdUserProprietario);
            //Relacionamento 1 : N | Proprietario : Posts
            builder.HasMany(p => p.Posts).WithOne(i => i.LoginProprietario).HasForeignKey(fk => fk.IdUserProprietario);

            builder.ToTable("login_proprietario");

        }
    }
}
