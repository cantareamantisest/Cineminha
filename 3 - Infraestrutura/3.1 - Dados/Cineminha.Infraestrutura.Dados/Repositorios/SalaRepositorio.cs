using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces.Repositorios;
using Cineminha.Infraestrutura.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Cineminha.Infraestrutura.Dados.Repositorios
{
    public class SalaRepositorio : RepositorioBase<Sala>, ISalaRepositorio
    {
        private readonly DbSet<Sala> _dbSetSala;

        public SalaRepositorio(CineminhaContexto dbContexto)
            : base(dbContexto)
        {
            _dbSetSala = dbContexto.Set<Sala>();
        }
    }
}