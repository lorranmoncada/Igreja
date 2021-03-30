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
    public class CategoriaIgrejaMap : IEntityTypeConfiguration<CategoriaIgreja>
    {
        public void Configure(EntityTypeBuilder<CategoriaIgreja> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").IsRequired();
            builder.Property(c => c.TipoCategoria).HasColumnName("tp_categoria").IsRequired();

            // Relacionamento  1:N Categoria : Igreja
            builder.HasMany(c => c.Igrejas).WithOne(c => c.CategoriaIgreja).HasForeignKey(fk => fk.CategoriaIgrejaId);

            builder.ToTable("tb_categoria_igreja");
        }
    }
}
