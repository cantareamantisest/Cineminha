using Cineminha.Dominio.Entidades;

namespace Cineminha.Dominio.Especificacao
{
    public class FilmeComSessoesEspecificacao : EspecificacaoBase<Filme>
    {
        public FilmeComSessoesEspecificacao()
            : base()
        {
            AddInclude(c => c.Sessoes);
        }

        public FilmeComSessoesEspecificacao(int id)
            : base(c => c.IdFilme == id)
        {
            AddInclude(c => c.Sessoes);
        }
    }
}