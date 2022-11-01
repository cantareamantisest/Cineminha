using Cineminha.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cineminha.Infraestrutura.Dados.Mapeamentos
{
    public class SessaoMapeamento : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("Sessao");

            builder.HasKey(c => c.IdSessao);

            builder.Property(c => c.IdSessao)
                .HasColumnType("int")
                .HasColumnName("IdSessao");

            builder.Property(c => c.Data)
               .HasColumnType("date")
               .HasColumnName("Data")
               .IsRequired();

            builder.Property(c => c.HoraInicio)
                .HasColumnType("time(0)")
                .HasColumnName("HoraInicio")
                .IsRequired();

            builder.Property(c => c.ValorIngresso)
                .HasColumnType("real")
                .HasColumnName("ValorIngresso")
                .IsRequired();

            builder.Property(c => c.TipoAnimacao)
                .HasColumnType("int")
                .HasColumnName("TipoAnimacao")
                .IsRequired();

            builder.Property(c => c.TipoAudio)
                .HasColumnType("int")
                .HasColumnName("TipoAudio")
                .IsRequired();

            builder.HasOne(c => c.Filme)
                .WithMany(c => c.Sessoes)
                .HasForeignKey(c => c.IdFilme)
                .IsRequired();

            builder.HasOne(c => c.Sala)
                .WithMany(c => c.Sessoes)
                .HasForeignKey(c => c.IdSala)
                .IsRequired();
        }
    }
}