using Igreja.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Igreja.Infraestructure.Mapping
{
    public class FielMap : IEntityTypeConfiguration<Fiel>
    {
        public void Configure(EntityTypeBuilder<Fiel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_fiel").IsRequired();
            builder.Property(c => c.IdLoginFiel).HasColumnName("id_fiel_login").IsRequired();
            builder.Property(c => c.NomeFiel).HasColumnName("nome_fiel").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Cpf).HasColumnName("cpf").HasMaxLength(11).IsRequired();
            builder.Property(c => c.DataCadastro).HasColumnName("data_cadastro").IsRequired();
            builder.Property(c => c.Telefone).HasColumnName("telefone").HasMaxLength(11).IsRequired();
            builder.Property(c => c.Email).HasColumnName("email").HasMaxLength(200).IsRequired();
            builder.Property(c => c.IdIgreja).HasColumnName("id_igreja").IsRequired();
            builder.Property(c => c.Cep).HasColumnName("cep").HasMaxLength(9).IsRequired();
            builder.Property(c => c.Endereco).HasColumnName("endereco").HasMaxLength(250).IsRequired();

            builder.ToTable("tb_fiel");
        }
    } 
    
}
