using Igreja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Infraestructure.Mapping
{
    public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_comentario").IsRequired();
            builder.Property(c => c.IdUser).HasColumnName("id_user").IsRequired();
            builder.Property(c => c.IdComentarioParent).HasColumnName("comentario_id");
            builder.Property(c => c.IdPost).HasColumnName("id_post");
            builder.Property(c => c.ComentarioUsuario).HasColumnName("comentario").HasMaxLength(3000).IsRequired();
            builder.Property(c => c.DataCadastro).HasColumnName("data_cadastro").IsRequired();

            builder.ToTable("tb_comentario");
        }
    }
}
