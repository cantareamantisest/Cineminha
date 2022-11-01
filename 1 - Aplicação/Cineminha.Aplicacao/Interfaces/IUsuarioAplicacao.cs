using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces;
using System.Linq.Expressions;

namespace Cineminha.Aplicacao.Interfaces
{
    public interface IUsuarioAplicacao
    {
        void Adicionar(UsuarioViewModel obj);

        UsuarioViewModel ObterPorId(int id);

        IEnumerable<UsuarioViewModel> ObterTodos();

        IEnumerable<UsuarioViewModel> Procurar(Expression<Func<Usuario, bool>> expressao);

        IEnumerable<UsuarioViewModel> ProcurarComEspecificacao(IEspecificacao<Usuario> especificacao = null);

        void Atualizar(UsuarioViewModel obj);

        void Remover(int id);

        string EncryptPassword(string clearText);

        string DecryptPassword(string cipherText);
    }
}