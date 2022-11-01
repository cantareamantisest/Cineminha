using Cineminha.Dominio.Entidades;
using System.Linq.Expressions;

namespace Cineminha.Dominio.Especificacao
{
    public class SessaoComFilmeSalaEspecificacao : EspecificacaoBase<Sessao>
    {

        public SessaoComFilmeSalaEspecificacao()
            : base()
        {
            AddInclude(c => c.Sala);
            AddInclude(c => c.Filme);
        }

        public SessaoComFilmeSalaEspecificacao(int id)
            : base(c => c.IdSessao == id)
        {
            AddInclude(c => c.Sala);
            AddInclude(c => c.Filme);
        }
    }
}