using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces.Repositorios;
using Cineminha.Infraestrutura.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Cineminha.Infraestrutura.Dados.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        private readonly DbSet<Usuario> _dbSetUsuario;

        public UsuarioRepositorio(CineminhaContexto dbContexto) 
            : base(dbContexto)
        {
            _dbSetUsuario = dbContexto.Set<Usuario>();
        }
    }
}