using Cineminha.Aplicacao.Interfaces;
using Cineminha.Aplicacao.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cineminha.Testes.Mocks
{
    internal class MockISessaoAplicacao
    {
        public static Mock<ISessaoAplicacao> GetMock()
        {
            var mock = new Mock<ISessaoAplicacao>();

            var listaSessoes = new List<SessaoViewModel>()
            {
                new SessaoViewModel
                {
                    IdFilme = 1,
                    IdSala = 1,
                    Data = DateTime.Now,
                    HoraInicio = new TimeSpan(15, 30, 00),
                    ValorIngresso = 35,
                    TipoAnimacao = 2,
                    TipoAudio = 1,
                    Sala = new SalaViewModel { IdSala = 1, Nome = "Sala 1", Assentos = 110 },
                    Filme = new FilmeViewModel { IdFilme = 1, Imagem = new byte[30], Titulo = "Filme Teste 1", Descricao = "Descrição Filme Teste 1", Duracao = 91 }
                },
                new SessaoViewModel 
                { 
                    IdFilme = 2, 
                    IdSala = 2, 
                    Data = DateTime.Now, 
                    HoraInicio = new TimeSpan(15, 30, 00), 
                    ValorIngresso = 35, 
                    TipoAnimacao = 2, 
                    TipoAudio = 1,
                    Sala = new SalaViewModel { IdSala = 2, Nome = "Sala 2", Assentos = 120 },
                    Filme = new FilmeViewModel { IdFilme = 2, Imagem = new byte[30], Titulo = "Filme Teste 2", Descricao = "Descrição Filme Teste 2", Duracao = 92 }
                },
                new SessaoViewModel
                {
                    IdFilme = 3,
                    IdSala = 3,
                    Data = DateTime.Now,
                    HoraInicio = new TimeSpan(15, 30, 00),
                    ValorIngresso = 35,
                    TipoAnimacao = 2,
                    TipoAudio = 1,
                    Sala = new SalaViewModel { IdSala = 3, Nome = "Sala 3", Assentos = 130 },
                    Filme = new FilmeViewModel { IdFilme = 3, Imagem = new byte[30], Titulo = "Filme Teste 3", Descricao = "Descrição Filme Teste 3", Duracao = 93 }
                },
                new SessaoViewModel
                {
                    IdFilme = 4,
                    IdSala = 4,
                    Data = DateTime.Now,
                    HoraInicio = new TimeSpan(15, 30, 00),
                    ValorIngresso = 35,
                    TipoAnimacao = 2,
                    TipoAudio = 1,
                    Sala = new SalaViewModel { IdSala = 4, Nome = "Sala 4", Assentos = 140 },
                    Filme = new FilmeViewModel { IdFilme = 4, Imagem = new byte[30], Titulo = "Filme Teste 4", Descricao = "Descrição Filme Teste 4", Duracao = 94 }
                },
                new SessaoViewModel
                {
                    IdFilme = 5,
                    IdSala = 5,
                    Data = DateTime.Now,
                    HoraInicio = new TimeSpan(15, 30, 00),
                    ValorIngresso = 35,
                    TipoAnimacao = 2,
                    TipoAudio = 1,
                    Sala = new SalaViewModel { IdSala = 5, Nome = "Sala 5", Assentos = 150 },
                    Filme = new FilmeViewModel { IdFilme = 5, Imagem = new byte[30], Titulo = "Filme Teste 5", Descricao = "Descrição Filme Teste 5", Duracao = 95 }
                }
            };

            mock.Setup(m => m.ObterTodos()).Returns(() => listaSessoes);

            mock.Setup(m => m.ObterPorId(It.IsAny<int>())).Returns((int id) => listaSessoes.FirstOrDefault(o => o.IdSessao == id));

            mock.Setup(m => m.Adicionar(It.IsAny<SessaoViewModel>())).Callback(() => { return; });

            mock.Setup(m => m.Atualizar(It.IsAny<SessaoViewModel>())).Callback(() => { return; });

            mock.Setup(m => m.Remover(It.IsAny<int>())).Callback(() => { return; });

            //mock.Setup(m=>m.VerificarSalaDisponivel(It.IsAny<FilmeViewModel>(), It.IsAny<SessaoViewModel>())).Returns(() =>            

            return mock;
        }
    }
}