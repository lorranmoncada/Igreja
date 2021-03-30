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
   public class IgrejaMap : IEntityTypeConfiguration<IgrejaEntity>
    {
        public void Configure(EntityTypeBuilder<IgrejaEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_igreja").IsRequired();
            builder.Property(c => c.Nome).HasColumnName("nome").IsRequired().HasMaxLength(200);
            builder.Property(c => c.Cnpj).HasColumnName("cnpj").IsRequired().HasMaxLength(50);
            builder.Property(c => c.DataCadastro).HasColumnName("data_cadastro").IsRequired();
            builder.Property(c => c.CategoriaIgrejaId).HasColumnName("id_categoria").IsRequired();
            builder.Property(c => c.ProprietarioId).HasColumnName("id_proprietario").IsRequired();
            builder.Property(c => c.EnderecoId).HasColumnName("id_endereco").IsRequired();

            builder.ToTable("tb_igreja");
        }
       
    }
}
