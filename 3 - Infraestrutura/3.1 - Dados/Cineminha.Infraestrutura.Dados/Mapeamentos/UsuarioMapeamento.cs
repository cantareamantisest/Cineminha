using Cineminha.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cineminha.Infraestrutura.Dados.Mapeamentos
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.IdUsuario);

            builder.Property(c => c.IdUsuario)
                .HasColumnType("int")
                .HasColumnName("IdUsuario");

            builder.Property(c => c.Nome)
              .HasColumnType("varchar(100)")
              .HasColumnName("Nome")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(c => c.Login)
               .HasColumnType("varchar(100)")
               .HasColumnName("Login")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(c => c.Senha)
               .HasColumnType("varchar(200)")
               .HasColumnName("Senha")
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(c => c.Funcao)
              .HasColumnType("varchar(100)")
              .HasColumnName("Funcao")
              .HasMaxLength(100)
              .IsRequired();
        }
    }
}