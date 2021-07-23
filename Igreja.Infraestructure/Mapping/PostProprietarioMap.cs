using Igreja.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Igreja.Infraestructure.Mapping
{
    public class PostProprietarioMap : IEntityTypeConfiguration<ProprietarioPost>
    {
        public void Configure(EntityTypeBuilder<ProprietarioPost> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("id_post").IsRequired();
            builder.Property(c => c.Post).HasColumnName("descricao").IsRequired().HasMaxLength(3000);
            builder.Property(c => c.DataCadastro).HasColumnName("data_cadastro").IsRequired();
            builder.Property(c => c.IdUserProprietario).HasColumnName("id_user_post").IsRequired();
          
            // Relacionamento  1:N Post : Comentários
            builder.HasMany(c => c.Comentarios).WithOne(x => x.Post).HasForeignKey(fk => fk.IdPost);

            builder.ToTable("tb_post");
        }
    }
}
