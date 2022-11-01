using AutoMapper;
using Cineminha.Aplicacao.Interfaces;
using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;
using Cineminha.Dominio.Especificacao;
using Cineminha.Dominio.Interfaces;
using Cineminha.Dominio.Interfaces.Repositorios;
using System.Linq.Expressions;

namespace Cineminha.Aplicacao.Servicos
{
    public class SessaoAplicacao : ISessaoAplicacao
    {
        private readonly IMapper _mapper;
        private readonly ISessaoRepositorio _sessaoRepositorio;

        public SessaoAplicacao(IMapper mapper, ISessaoRepositorio sessaoRepositorio)
        {
            _mapper = mapper;
            _sessaoRepositorio = sessaoRepositorio;
        }

        public SessaoViewModel ObterPorId(int id)
        {
            return _mapper.Map<SessaoViewModel>(_sessaoRepositorio.ObterPorId(id));
        }

        public IEnumerable<SessaoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<SessaoViewModel>>(_sessaoRepositorio.ObterTodos());
        }

        public IEnumerable<SessaoViewModel> Procurar(Expression<Func<Sessao, bool>> expressao)
        {
            return _mapper.Map<IEnumerable<SessaoViewModel>>(_sessaoRepositorio.Procurar(expressao));
        }

        public IEnumerable<SessaoViewModel> ProcurarComEspecificacao(IEspecificacao<Sessao> especificacao = null)
        {
            return _mapper.Map<IEnumerable<SessaoViewModel>>(_sessaoRepositorio.ProcurarComEspecificacao(especificacao));
        }

        public void Adicionar(SessaoViewModel obj)
        {
            _sessaoRepositorio.Adicionar(_mapper.Map<Sessao>(obj));
        }

        public void Atualizar(SessaoViewModel obj)
        {
            _sessaoRepositorio.Atualizar(_mapper.Map<Sessao>(obj));
        }

        public void Remover(int id)
        {
            _sessaoRepositorio.Remover(id);
        }

        public bool VerificarSalaDisponivel(FilmeViewModel filmeViewModel, SessaoViewModel sessaoViewModel)
        {
            var listaSessoes = _sessaoRepositorio.ProcurarComEspecificacao(new SessaoComFilmeObterPorIdSalaEspecificacao(sessaoViewModel.IdSala));
            if (listaSessoes.Any())
            {
                var ultimoIdSessao = listaSessoes.LastOrDefault().IdSessao;
                foreach (var sessao in listaSessoes)
                {
                    if (sessaoViewModel.Data != sessao.Data)
                    {
                        if (ultimoIdSessao == sessao.IdSessao)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        var horaTerminoControle = sessaoViewModel.HoraInicio.Add(TimeSpan.FromMinutes(filmeViewModel.Duracao));
                        var terminoSessaoCadastrado = sessao.HoraInicio.Add(TimeSpan.FromMinutes(sessao.Filme.Duracao));
                        if ((horaTerminoControle < sessao.HoraInicio) || (sessaoViewModel.HoraInicio > terminoSessaoCadastrado))
                        {
                            if (ultimoIdSessao == sessao.IdSessao)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
    }
}