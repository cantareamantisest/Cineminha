using Cineminha.Aplicacao.Interfaces;
using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Especificacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;

namespace Cineminha.Apresentacao.Mvc.Controllers
{
    [Authorize(Roles = "Gerente")]
    public class SessionManagerController : BaseController
    {
        private readonly ISessaoAplicacao _sessaoAplicacao;
        private readonly IFilmeAplicacao _filmeAplicacao;
        private readonly ISalaAplicacao _salaAplicacao;

        public SessionManagerController(ISessaoAplicacao sessaoAplicacao, IFilmeAplicacao filmeAplicacao, ISalaAplicacao salaAplicacao)
        {
            _sessaoAplicacao = sessaoAplicacao;
            _filmeAplicacao = filmeAplicacao;
            _salaAplicacao = salaAplicacao;
        }

        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var listaSessoes = _sessaoAplicacao.ProcurarComEspecificacao(new SessaoComFilmeSalaEspecificacao());
            var listaSessoesPaginada = PagingList.Create(listaSessoes, 10, pageNumber);
            return View(listaSessoesPaginada);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var listaFilmes = _filmeAplicacao.ObterTodos().ToList();
            var listaSalas = _salaAplicacao.ObterTodos().ToList();

            var selectListFilmes = new List<SelectListItem>();
            var selectListSalas = new List<SelectListItem>();
            var selectListAnimacao = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "2D" },
                new SelectListItem { Value = "2", Text = "3D" }
            };
            var selectListAudio = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Original" },
                new SelectListItem { Value = "2", Text = "Dublado" }
            };

            listaFilmes.ForEach(c => selectListFilmes.Add(new SelectListItem { Value = c.IdFilme.ToString(), Text = c.Titulo }));
            listaSalas.ForEach(c => selectListSalas.Add(new SelectListItem { Value = c.IdSala.ToString(), Text = c.Nome }));

            var novaSessao = new SessaoViewModel { SelectListFilme = selectListFilmes, SelectListSala = selectListSalas, SelectListTipoAnimacao = selectListAnimacao, SelectListTipoAudio = selectListAudio };

            return PartialView("_CreateSessionManager", novaSessao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SessaoViewModel sessao)
        {
            var listaFilmes = _filmeAplicacao.ObterTodos().ToList();
            var listaSalas = _salaAplicacao.ObterTodos().ToList();

            var selectListFilmes = new List<SelectListItem>();
            var selectListSalas = new List<SelectListItem>();
            var selectListAnimacao = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "2D" },
                new SelectListItem { Value = "2", Text = "3D" }
            };
            var selectListAudio = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Original" },
                new SelectListItem { Value = "2", Text = "Dublado" }
            };

            listaFilmes.ForEach(c => selectListFilmes.Add(new SelectListItem { Value = c.IdFilme.ToString(), Text = c.Titulo }));
            listaSalas.ForEach(c => selectListSalas.Add(new SelectListItem { Value = c.IdSala.ToString(), Text = c.Nome }));

            var novaSessao = new SessaoViewModel { SelectListFilme = selectListFilmes, SelectListSala = selectListSalas, SelectListTipoAnimacao = selectListAnimacao, SelectListTipoAudio = selectListAudio };

            if (ModelState.IsValid)
            {
                var filme = _filmeAplicacao.ObterPorId(sessao.IdFilme);
                if (_sessaoAplicacao.VerificarSalaDisponivel(filme, sessao))
                {
                    _sessaoAplicacao.Adicionar(sessao);
                    ModelState.Clear();
                    Notify("Sessão adicionada com sucesso.", "Informação ao usuário", Models.NotificationType.success);
                    return PartialView("_CreateSessionManager", novaSessao);
                }
                ModelState.AddModelError("HoraInicio", "Horário definido em conflito com sessão já cadastrada!");
                return PartialView("_CreateSessionManager", novaSessao);
            }
            return PartialView("_CreateSessionManager", novaSessao);
        }

        #region Editar Sessão
        //[HttpGet]
        //[Route("SessionManager/Edit/{id}")]
        //public IActionResult Edit(int id)
        //{
        //    var sessao = _sessaoAplicacao.ObterPorId(id);

        //    var listaFilmes = _filmeAplicacao.ObterTodos().ToList();
        //    var listaSalas = _salaAplicacao.ObterTodos().ToList();

        //    var selectListFilmes = new List<SelectListItem>();
        //    var selectListSalas = new List<SelectListItem>();
        //    var selectListAnimacao = new List<SelectListItem>
        //    {
        //        new SelectListItem { Value = "1", Text = "2D", Selected = sessao.TipoAnimacao == 1 },
        //        new SelectListItem { Value = "2", Text = "3D", Selected = sessao.TipoAnimacao == 2 }
        //    };
        //    var selectListAudio = new List<SelectListItem>
        //    {
        //        new SelectListItem { Value = "1", Text = "Original", Selected = sessao.TipoAudio == 1 },
        //        new SelectListItem { Value = "2", Text = "Dublado", Selected = sessao.TipoAudio == 2 }
        //    };

        //    listaFilmes.ForEach(c => selectListFilmes.Add(new SelectListItem { Value = c.IdFilme.ToString(), Text = c.Titulo, Selected = c.IdFilme == sessao.IdFilme }));
        //    listaSalas.ForEach(c => selectListSalas.Add(new SelectListItem { Value = c.IdSala.ToString(), Text = c.Nome, Selected = c.IdSala == sessao.IdSala }));

        //    sessao.SelectListFilme = selectListFilmes;
        //    sessao.SelectListSala = selectListSalas;
        //    sessao.SelectListTipoAnimacao = selectListAnimacao;
        //    sessao.SelectListTipoAudio = selectListAudio;

        //    return PartialView("_EditSessionManager", sessao);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route($"SessionManager/Edit/{nameof(SessaoViewModel)}")]
        //public IActionResult Edit(SessaoViewModel sessao)
        //{
        //    var listaFilmes = _filmeAplicacao.ObterTodos().ToList();
        //    var listaSalas = _salaAplicacao.ObterTodos().ToList();

        //    var selectListFilmes = new List<SelectListItem>();
        //    var selectListSalas = new List<SelectListItem>();
        //    var selectListAnimacao = new List<SelectListItem>
        //    {
        //        new SelectListItem { Value = "1", Text = "2D", Selected = sessao.TipoAnimacao == 1 },
        //        new SelectListItem { Value = "2", Text = "3D", Selected = sessao.TipoAnimacao == 2 }
        //    };
        //    var selectListAudio = new List<SelectListItem>
        //    {
        //        new SelectListItem { Value = "1", Text = "Original", Selected = sessao.TipoAudio == 1 },
        //        new SelectListItem { Value = "2", Text = "Dublado", Selected = sessao.TipoAudio == 2 }
        //    };

        //    listaFilmes.ForEach(c => selectListFilmes.Add(new SelectListItem { Value = c.IdFilme.ToString(), Text = c.Titulo, Selected = c.IdFilme == sessao.IdFilme }));
        //    listaSalas.ForEach(c => selectListSalas.Add(new SelectListItem { Value = c.IdSala.ToString(), Text = c.Nome, Selected = c.IdSala == sessao.IdSala }));
        //    var novaSessao = new SessaoViewModel { SelectListFilme = selectListFilmes, SelectListSala = selectListSalas, SelectListTipoAnimacao = selectListAnimacao, SelectListTipoAudio = selectListAudio };

        //    if (ModelState.IsValid)
        //    {
        //        _sessaoAplicacao.Atualizar(sessao);
        //        ModelState.Clear();
        //        return PartialView("_EditSessionManager", novaSessao);
        //    }

        //    sessao.SelectListFilme = selectListFilmes;
        //    sessao.SelectListSala = selectListSalas;
        //    sessao.SelectListTipoAnimacao = selectListAnimacao;
        //    sessao.SelectListTipoAudio = selectListAudio;

        //    return PartialView("_EditSessionManager", sessao);
        //}
        #endregion Editar Sessão

        [HttpGet]
        [Route("SessionManager/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var sessao = _sessaoAplicacao.ObterPorId(id);
            var dataSessao = new DateTime(sessao.Data.Year, sessao.Data.Month, sessao.Data.Day, sessao.HoraInicio.Hours, sessao.HoraInicio.Minutes, 0);
            var dataSessaoPermitidaRemover = dataSessao.AddDays(-10);
            if (DateTime.Now < dataSessaoPermitidaRemover)
            {
                return PartialView("_DeleteSessionManager", sessao);
            }
            return PartialView("_DeleteSessionNotAllowed");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("SessionManager/Delete/{id}")]
        public IActionResult DeleteConfirm(int id)
        {
            _sessaoAplicacao.Remover(id);
            Notify("Sessão excluída com sucesso.", "Informação ao usuário", Models.NotificationType.success);
            return PartialView("_DeleteSessionManager");
        }
    }
}