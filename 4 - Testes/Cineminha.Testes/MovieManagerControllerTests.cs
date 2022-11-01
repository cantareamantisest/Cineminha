using Cineminha.Aplicacao.ViewModels;
using Cineminha.Apresentacao.Mvc.Controllers;
using Cineminha.Testes.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cineminha.Testes
{
    public class MovieManagerControllerTests
    {

        [Fact]
        public void QuandoObterTodosFilmes_EntaoRetornarTodosFilmes()
        {
            var mockFilmeAplicacao = MockIFilmeAplicacao.GetMock();

            var movieManagerController = new MovieManagerController(mockFilmeAplicacao.Object);

            var result = movieManagerController.Index(1) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<FilmeViewModel>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<FilmeViewModel>);
        }
    }
}
