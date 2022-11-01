using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces;
using System.Linq.Expressions;

namespace Cineminha.Aplicacao.Interfaces
{
    public interface ISessaoAplicacao
    {
        void Adicionar(SessaoViewModel obj);

        SessaoViewModel ObterPorId(int id);

        IEnumerable<SessaoViewModel> ObterTodos();

        IEnumerable<SessaoViewModel> Procurar(Expression<Func<Sessao, bool>> expressao);

        IEnumerable<SessaoViewModel> ProcurarComEspecificacao(IEspecificacao<Sessao> especificacao = null);

        void Atualizar(SessaoViewModel obj);

        void Remover(int id);

        bool VerificarSalaDisponivel(FilmeViewModel filmeViewModel, SessaoViewModel sessaoViewModel);
    }
}