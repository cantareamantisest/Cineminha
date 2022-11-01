using Cineminha.Aplicacao.Interfaces;
using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;
using Moq;
using System.Linq.Expressions;

namespace Cineminha.Testes.Mocks
{
    internal class MockIFilmeAplicacao
    {
        public static Mock<IFilmeAplicacao> GetMock()
        {
            var mock = new Mock<IFilmeAplicacao>();

            var listaFilmes = new List<FilmeViewModel>()
            {
                new FilmeViewModel 
                { 
                    IdFilme = 1, 
                    Imagem = new byte[30], 
                    Titulo = "Filme Teste 1", 
                    Descricao = "Descrição Filme Teste 1", 
                    Duracao = 91,
                    Sessoes = new List<SessaoViewModel>()
                    {
                        new SessaoViewModel { IdFilme = 1, IdSala = 1, Data = DateTime.Now, HoraInicio = new TimeSpan(15, 30, 00), ValorIngresso = 35, TipoAnimacao = 2, TipoAudio = 1 }
                    }
                },
                new FilmeViewModel 
                { 
                    IdFilme = 2, 
                    Imagem = new byte[30], 
                    Titulo = "Filme Teste 2",
                    Descricao = "Descrição Filme Teste 2", 
                    Duracao = 92,
                    Sessoes= new List<SessaoViewModel>()
                    {
                        new SessaoViewModel { IdFilme = 2, IdSala = 2, Data = DateTime.Now, HoraInicio = new TimeSpan(15, 30, 00), ValorIngresso = 35, TipoAnimacao = 2, TipoAudio = 1 }
                    }
                },
                new FilmeViewModel 
                { 
                    IdFilme = 3, 
                    Imagem = new byte[30], 
                    Titulo = "Filme Teste 3",
                    Descricao = "Descrição Filme Teste 3", 
                    Duracao = 93,
                    Sessoes = new List<SessaoViewModel>()
                    {
                        new SessaoViewModel { IdFilme = 3, IdSala = 3, Data = DateTime.Now, HoraInicio = new TimeSpan(15, 30, 00), ValorIngresso = 35, TipoAnimacao = 2, TipoAudio = 1 }
                    }
                },
                new FilmeViewModel 
                { 
                    IdFilme = 4, 
                    Imagem = new byte[30], 
                    Titulo = "Filme Teste 4", 
                    Descricao = "Descrição Filme Teste 4",
                    Duracao = 94,
                    Sessoes = new List<SessaoViewModel>()
                    {
                        new SessaoViewModel { IdFilme = 4, IdSala = 4, Data = DateTime.Now, HoraInicio = new TimeSpan(15, 30, 00), ValorIngresso = 35, TipoAnimacao = 2, TipoAudio = 1 }
                    } 
                },
                new FilmeViewModel 
                { 
                    IdFilme = 5, 
                    Imagem = new byte[30], 
                    Titulo = "Filme Teste 5",
                    Descricao = "Descrição Filme Teste 5", 
                    Duracao = 75,
                    Sessoes = new List<SessaoViewModel>()
                    {
                        new SessaoViewModel { IdFilme = 5, IdSala = 5, Data = DateTime.Now, HoraInicio = new TimeSpan(15, 30, 00), ValorIngresso = 35, TipoAnimacao = 2, TipoAudio = 1 }
                    }
                }
            };

            mock.Setup(m => m.ObterTodos()).Returns(() => listaFilmes);

            mock.Setup(m => m.ObterPorId(It.IsAny<int>())).Returns((int id) => listaFilmes.FirstOrDefault(o => o.IdFilme == id));

            mock.Setup(m => m.Adicionar(It.IsAny<FilmeViewModel>())).Callback(() => { return; });

            mock.Setup(m => m.Atualizar(It.IsAny<FilmeViewModel>())).Callback(() => { return; });

            mock.Setup(m => m.Remover(It.IsAny<int>())).Callback(() => { return; });

            mock.Setup(m => m.ExisteFilmeCadastrado(It.IsAny<FilmeViewModel>())).Returns((FilmeViewModel filme) => listaFilmes.Any(o => o.IdFilme != filme.IdFilme && o.Titulo == filme.Titulo));

            return mock;
        }
    }
}
