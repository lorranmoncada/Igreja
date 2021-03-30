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
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_endereco").IsRequired();
            builder.Property(c => c.NomeEndereco).HasColumnName("nome_endereco").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Cep).HasColumnName("cep").IsRequired().HasMaxLength(50);
            
            // Relacionamento  1 : N | Endereco : Igreja
            builder.HasMany(i => i.Igrejas).WithOne(e => e.Endereco).HasForeignKey(fk => fk.EnderecoId);

            builder.ToTable("tb_endereco");
        }
    }
}
