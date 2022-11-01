using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces;
using System.Linq.Expressions;

namespace Cineminha.Aplicacao.Interfaces
{
    public interface IFilmeAplicacao
    {
        void Adicionar(FilmeViewModel obj);

        FilmeViewModel ObterPorId(int id);

        IEnumerable<FilmeViewModel> ObterTodos();

        IEnumerable<FilmeViewModel> Procurar(Expression<Func<Filme, bool>> expressao);

        IEnumerable<FilmeViewModel> ProcurarComEspecificacao(IEspecificacao<Filme> especificacao = null);

        void Atualizar(FilmeViewModel obj);

        void Remover(int id);

        bool ExisteFilmeCadastrado(FilmeViewModel filme);
    }
}