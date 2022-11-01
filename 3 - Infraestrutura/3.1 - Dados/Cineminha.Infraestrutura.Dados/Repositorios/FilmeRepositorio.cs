using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces.Repositorios;
using Cineminha.Infraestrutura.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Cineminha.Infraestrutura.Dados.Repositorios
{
    public class FilmeRepositorio : RepositorioBase<Filme>, IFilmeRepositorio
    {
        private readonly DbSet<Filme> _dbSetFilme;

        public FilmeRepositorio(CineminhaContexto dbContexto)
            : base(dbContexto)
        {
            _dbSetFilme = dbContexto.Set<Filme>();
        }
    }
}