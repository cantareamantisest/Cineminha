using Cineminha.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cineminha.Infraestrutura.Dados.Mapeamentos
{
    public class FilmeMapeamento : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filme");

            builder.HasKey(c => c.IdFilme);

            builder.Property(c => c.IdFilme)
                .HasColumnType("int")
                .HasColumnName("IdFilme");

            builder.Property(c => c.Imagem)
               .HasColumnType("varbinary(MAX)")
               .HasColumnName("Imagem")
               .IsRequired();

            builder.Property(c => c.Titulo)
               .HasColumnType("varchar(200)")
               .HasColumnName("Titulo")
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(200)")
               .HasColumnName("Descricao")
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(c => c.Duracao)
               .HasColumnType("int")
               .HasColumnName("Duracao")
               .IsRequired();
        }
    }
}