using AutoMapper;
using Cineminha.Aplicacao.Interfaces;
using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Interfaces;
using Cineminha.Dominio.Interfaces.Repositorios;
using System.Linq.Expressions;

namespace Cineminha.Aplicacao.Servicos
{
    public class SalaAplicacao : ISalaAplicacao
    {
        private readonly IMapper _mapper;
        private readonly ISalaRepositorio _salaRepositorio;

        public SalaAplicacao(IMapper mapper, ISalaRepositorio salaRepositorio)
        {
            _mapper = mapper;
            _salaRepositorio = salaRepositorio;
        }

        public SalaViewModel ObterPorId(int id)
        {
            return _mapper.Map<SalaViewModel>(_salaRepositorio.ObterPorId(id));
        }

        public IEnumerable<SalaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<SalaViewModel>>(_salaRepositorio.ObterTodos());
        }

        public IEnumerable<SalaViewModel> Procurar(Expression<Func<Sala, bool>> expressao)
        {
            return _mapper.Map<IEnumerable<SalaViewModel>>(_salaRepositorio.Procurar(expressao));
        }

        public IEnumerable<SalaViewModel> ProcurarComEspecificacao(IEspecificacao<Sala> especificacao = null)
        {
            return _mapper.Map<IEnumerable<SalaViewModel>>(_salaRepositorio.ProcurarComEspecificacao(especificacao));
        }

        public void Adicionar(SalaViewModel obj)
        {
            _salaRepositorio.Adicionar(_mapper.Map<Sala>(obj));
        }

        public void Atualizar(SalaViewModel obj)
        {
            _salaRepositorio.Atualizar(_mapper.Map<Sala>(obj));
        }

        public void Remover(int id)
        {
            _salaRepositorio.Remover(id);
        }
    }
}