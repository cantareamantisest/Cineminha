// <auto-generated />
using System;
using Cineminha.Infraestrutura.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cineminha.Infraestrutura.Dados.Migrations
{
    [DbContext(typeof(CineminhaContexto))]
    partial class CineminhaContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cineminha.Dominio.Entidades.Filme", b =>
                {
                    b.Property<int>("IdFilme")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdFilme");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFilme"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Descricao");

                    b.Property<int>("Duracao")
                        .HasColumnType("int")
                        .HasColumnName("Duracao");

                    b.Property<byte[]>("Imagem")
                        .IsRequired()
                        .HasColumnType("varbinary(MAX)")
                        .HasColumnName("Imagem");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Titulo");

                    b.HasKey("IdFilme");

                    b.ToTable("Filme", (string)null);
                });

            modelBuilder.Entity("Cineminha.Dominio.Entidades.Sala", b =>
                {
                    b.Property<int>("IdSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdSala");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSala"), 1L, 1);

                    b.Property<int>("Assentos")
                        .HasColumnType("int")
                        .HasColumnName("Assentos");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Nome");

                    b.HasKey("IdSala");

                    b.ToTable("Sala", (string)null);
                });

            modelBuilder.Entity("Cineminha.Dominio.Entidades.Sessao", b =>
                {
                    b.Property<int>("IdSessao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdSessao");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSessao"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("date")
                        .HasColumnName("Data");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time(0)")
                        .HasColumnName("HoraInicio");

                    b.Property<int>("IdFilme")
                        .HasColumnType("int");

                    b.Property<int>("IdSala")
                        .HasColumnType("int");

                    b.Property<int>("TipoAnimacao")
                        .HasColumnType("int")
                        .HasColumnName("TipoAnimacao");

                    b.Property<int>("TipoAudio")
                        .HasColumnType("int")
                        .HasColumnName("TipoAudio");

                    b.Property<float>("ValorIngresso")
                        .HasColumnType("real")
                        .HasColumnName("ValorIngresso");

                    b.HasKey("IdSessao");

                    b.HasIndex("IdFilme");

                    b.HasIndex("IdSala");

                    b.ToTable("Sessao", (string)null);
                });

            modelBuilder.Entity("Cineminha.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Funcao");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Senha");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Cineminha.Dominio.Entidades.Sessao", b =>
                {
                    b.HasOne("Cineminha.Dominio.Entidades.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cineminha.Dominio.Entidades.Sala", "Sala")
                        .WithMany("Sessoes")
                        .HasForeignKey("IdSala")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Cineminha.Dominio.Entidades.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("Cineminha.Dominio.Entidades.Sala", b =>
                {
                    b.Navigation("Sessoes");
                });
#pragma warning restore 612, 618
        }
    }
}
