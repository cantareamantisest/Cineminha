using Cineminha.Dominio.Interfaces;
using Cineminha.Dominio.Interfaces.Repositorios;
using Cineminha.Infraestrutura.Dados.Contexto;
using Cineminha.Infraestrutura.Dados.Especificacao;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cineminha.Infraestrutura.Dados.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
    {
        protected readonly CineminhaContexto _dbContexto;
        protected readonly DbSet<TEntidade> _dbSet;

        public RepositorioBase(CineminhaContexto dbContexto)
        {
            _dbContexto = dbContexto ?? throw new ArgumentException(nameof(dbContexto));
            _dbSet = _dbContexto.Set<TEntidade>();
        }        

        public TEntidade ObterPorId(int id) => _dbSet.Find(id);

        public IEnumerable<TEntidade> ObterTodos() => _dbSet.ToList();

        public IEnumerable<TEntidade> Procurar(Expression<Func<TEntidade, bool>> expressao) => _dbSet.Where(expressao).ToList();

        public IEnumerable<TEntidade> ProcurarComEspecificacao(IEspecificacao<TEntidade> especificacao = null) => EspecificacaoEvaluator<TEntidade>.GetQuery(_dbSet.AsQueryable(), especificacao);
 
        public void Adicionar(TEntidade obj)
        {
            _dbSet.Add(obj);
            Salvar();
        }

        public void Atualizar(TEntidade obj)
        {
            _dbSet.Update(obj);
            Salvar();
        }

        public void Remover(int id)
        {
            _dbSet.Remove(ObterPorId(id));
            Salvar();
        }

        private void Salvar() => _dbContexto.SaveChanges();
    }
}