using Cineminha.Dominio.Entidades;
using Cineminha.Infraestrutura.Dados.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Cineminha.Infraestrutura.Dados.Contexto
{
    public class CineminhaContexto : DbContext
    {
        public CineminhaContexto(DbContextOptions<CineminhaContexto> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeMapeamento());
            modelBuilder.ApplyConfiguration(new SalaMapeamento());
            modelBuilder.ApplyConfiguration(new SessaoMapeamento());
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());

            base.OnModelCreating(modelBuilder);
        }
    }
}