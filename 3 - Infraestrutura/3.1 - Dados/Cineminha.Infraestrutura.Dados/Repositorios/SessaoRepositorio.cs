using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces.Repositorios;
using Cineminha.Infraestrutura.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Cineminha.Infraestrutura.Dados.Repositorios
{
    public class SessaoRepositorio : RepositorioBase<Sessao>, ISessaoRepositorio
    {
        private readonly DbSet<Sessao> _dbSetSessao;

        public SessaoRepositorio(CineminhaContexto dbContexto) 
            : base(dbContexto)
        {
            _dbSetSessao = dbContexto.Set<Sessao>();
        }
    }
}