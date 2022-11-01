using Cineminha.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace Cineminha.Apresentacao.Mvc.Controllers
{
    [Authorize]
    public class MovieRoomController : BaseController
    {
        private readonly ISalaAplicacao _salaAplicacao;

        public MovieRoomController(ISalaAplicacao salaAplicacao)
        {
            _salaAplicacao = salaAplicacao;
        }

        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var listaSala = _salaAplicacao.ObterTodos();
            var listaSalaPaginada = PagingList.Create(listaSala, 10, pageNumber);
            return View(listaSalaPaginada);
        }
    }
}
