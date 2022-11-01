using AutoMapper;
using Cineminha.Aplicacao.Interfaces;
using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces;
using Cineminha.Dominio.Interfaces.Repositorios;
using System.Linq.Expressions;

namespace Cineminha.Aplicacao.Servicos
{
    public class FilmeAplicacao : IFilmeAplicacao
    {
        private readonly IMapper _mapper;
        private readonly IFilmeRepositorio _filmeRepositorio;

        public FilmeAplicacao(IMapper mapper, IFilmeRepositorio filmeRepositorio)
        {
            _mapper = mapper;
            _filmeRepositorio = filmeRepositorio;
        }

        public FilmeViewModel ObterPorId(int id)
        {
            return _mapper.Map<FilmeViewModel>(_filmeRepositorio.ObterPorId(id));
        }

        public IEnumerable<FilmeViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FilmeViewModel>>(_filmeRepositorio.ObterTodos());
        }

        public IEnumerable<FilmeViewModel> Procurar(Expression<Func<Filme, bool>> expressao)
        {
            return _mapper.Map<IEnumerable<FilmeViewModel>>(_filmeRepositorio.Procurar(expressao));
        }

        public IEnumerable<FilmeViewModel> ProcurarComEspecificacao(IEspecificacao<Filme> especificacao = null)
        {
            return _mapper.Map<IEnumerable<FilmeViewModel>>(_filmeRepositorio.ProcurarComEspecificacao(especificacao));
        }

        public void Adicionar(FilmeViewModel obj)
        {
            _filmeRepositorio.Adicionar(_mapper.Map<Filme>(obj));
        }

        public void Atualizar(FilmeViewModel obj)
        {
            _filmeRepositorio.Atualizar(_mapper.Map<Filme>(obj));
        }

        public void Remover(int id)
        {
            _filmeRepositorio.Remover(id);
        }

        public bool ExisteFilmeCadastrado(FilmeViewModel filme)
        {
            return _filmeRepositorio.Procurar(c => c.IdFilme != filme.IdFilme && c.Titulo == filme.Titulo).Any();
        }
    }
}