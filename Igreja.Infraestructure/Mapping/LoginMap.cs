
using Igreja.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Igreja.Infraestructure.Mapping
{
    public class LoginMap : IEntityTypeConfiguration<LoginFiel>
    {
        public void Configure(EntityTypeBuilder<LoginFiel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_fiel").IsRequired();
            builder.Property(c => c.Login).HasColumnName("login").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Senha).HasColumnName("senha").HasMaxLength(10).IsRequired();
            builder.Property(c => c.DataCadastro).HasColumnName("data_cadastro").IsRequired();

            //Relacionamento 
            // 1 : 1 | Login : Fiel
            builder.HasOne(l => l.Fiel).WithOne(f => f.LoginFiel).HasForeignKey<Fiel>(fk => fk.IdLoginFiel);

            builder.ToTable("tb_login_fiel");
        }
    }
}
