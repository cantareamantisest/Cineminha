using Cineminha.Dominio.Entidades;

namespace Cineminha.Dominio.Especificacao
{
    public class SessaoComFilmeObterPorIdSalaEspecificacao : EspecificacaoBase<Sessao>
    {
        public SessaoComFilmeObterPorIdSalaEspecificacao(int idSala)
            : base(c => c.IdSala == idSala)
        {
            AddInclude(c => c.Filme);
        }
    }
}