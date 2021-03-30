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
    public class ProprietarioMap : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_proprietario").IsRequired();
            builder.Property(c => c.NomeProprietario).HasColumnName("nome_proprietario").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Cpf).HasColumnName("cpf").IsRequired().HasMaxLength(50);
            builder.Property(c => c.DataCadastro).HasColumnName("data_cadastro").IsRequired();
            builder.Property(c => c.IdUserProprietario).HasColumnName("id_user_proprietario").IsRequired();

            //Relacionamento 1 : N | Proprietario : Igreja
            builder.HasMany(p => p.Igrejas).WithOne(i => i.Proprietario).HasForeignKey(fk => fk.ProprietarioId);

            builder.ToTable("tb_proprietario");
        }
    }
}
