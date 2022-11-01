using System.Linq.Expressions;

namespace Cineminha.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntitidade> where TEntitidade : class
    {
        void Adicionar(TEntitidade obj);

        TEntitidade ObterPorId(int id);

        IEnumerable<TEntitidade> ObterTodos();

        IEnumerable<TEntitidade> Procurar(Expression<Func<TEntitidade, bool>> expressao);

        IEnumerable<TEntitidade> ProcurarComEspecificacao(IEspecificacao<TEntitidade> especificacao = null);

        void Atualizar(TEntitidade obj);

        void Remover(int id);
    }
}