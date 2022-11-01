using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces;
using System.Linq.Expressions;

namespace Cineminha.Aplicacao.Interfaces
{
    public interface ISalaAplicacao
    {
        void Adicionar(SalaViewModel obj);

        SalaViewModel ObterPorId(int id);

        IEnumerable<SalaViewModel> ObterTodos();

        IEnumerable<SalaViewModel> Procurar(Expression<Func<Sala, bool>> expressao);

        IEnumerable<SalaViewModel> ProcurarComEspecificacao(IEspecificacao<Sala> especificacao = null);

        void Atualizar(SalaViewModel obj);

        void Remover(int id);
    }
}