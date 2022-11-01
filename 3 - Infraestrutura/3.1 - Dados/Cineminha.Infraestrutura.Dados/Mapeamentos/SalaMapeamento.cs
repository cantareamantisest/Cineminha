using Cineminha.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cineminha.Infraestrutura.Dados.Mapeamentos
{
    public class SalaMapeamento : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("Sala");

            builder.HasKey(c => c.IdSala);

            builder.Property(c => c.IdSala)
                .HasColumnType("int")
                .HasColumnName("IdSala");

            builder.Property(c => c.Nome)
               .HasColumnType("varchar(200)")
               .HasColumnName("Nome")
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(c => c.Assentos)
               .HasColumnType("int")
               .HasColumnName("Assentos")
               .IsRequired();
        }
    }
}