using Cineminha.Aplicacao.Interfaces;
using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Especificacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace Cineminha.Apresentacao.Mvc.Controllers
{
    [Authorize(Roles = "Gerente")]
    public class MovieManagerController : BaseController
    {
        private readonly IFilmeAplicacao _filmeAplicacao;

        public MovieManagerController(IFilmeAplicacao filmeAplicacao)
        {
            _filmeAplicacao = filmeAplicacao;
        }

        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var listaFilmes = _filmeAplicacao.ObterTodos();
            var listaFilmesPaginada = PagingList.Create(listaFilmes, 10, pageNumber);
            return View(listaFilmesPaginada);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var filme = new FilmeViewModel();
            return PartialView("_CreateMovieManager", filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilmeViewModel filme)
        {
            if (ModelState.IsValid)
            {
                if (filme.UploadImage != null && filme.UploadImage.Length > 0)
                {
                    if ("image/jpeg" == filme.UploadImage.ContentType)
                    {
                        if (!_filmeAplicacao.ExisteFilmeCadastrado(filme))
                        {
                            using var ms = new MemoryStream();
                            await filme.UploadImage.CopyToAsync(ms);
                            if (ms.Length < 2097152)
                            {
                                filme.Imagem = ms.ToArray();
                                _filmeAplicacao.Adicionar(filme);
                                ModelState.Clear();
                                Notify("Filme adicionado com sucesso.", "Informação ao usuário", Models.NotificationType.success);
                                return PartialView("_CreateMovieManager");
                            }
                            ModelState.AddModelError("UploadImage", "Imagem excedeu o tamanho máximo permitido de 2 MB!");
                            return PartialView("_CreateMovieManager");
                        }
                        ModelState.AddModelError("Titulo", "Título do filme já cadastrado!");
                        return PartialView("_CreateMovieManager");
                    }
                    ModelState.AddModelError("UploadImage", "Arquivo não suportado!");
                    return PartialView("_CreateMovieManager");
                }
                ModelState.AddModelError("UploadImage", "Nenhuma imagem carregada!");
                return PartialView("_CreateMovieManager");
            }
            return PartialView("_CreateMovieManager", filme);
        }

        [HttpGet]
        [Route("MovieManager/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var filme = _filmeAplicacao.ObterPorId(id);
            return PartialView("_EditMovieManager", filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route($"MovieManager/Edit/{nameof(FilmeViewModel)}")]
        public async  Task<IActionResult> Edit(FilmeViewModel filme)
        {
            if (ModelState.IsValid)
            {
                if (filme.UploadImage != null && filme.UploadImage.Length > 0)
                {
                    if ("image/jpeg" == filme.UploadImage.ContentType)
                    {
                        if (!_filmeAplicacao.ExisteFilmeCadastrado(filme))
                        {
                            using var ms = new MemoryStream();
                            await filme.UploadImage.CopyToAsync(ms);
                            if (ms.Length < 2097152)
                            {
                                filme.Imagem = ms.ToArray();
                                _filmeAplicacao.Atualizar(filme);
                                ModelState.Clear();
                                Notify("Filme editado com sucesso.", "Informação ao usuário", Models.NotificationType.success);
                                return PartialView("_EditMovieManager");
                            }
                            ModelState.AddModelError("UploadImage", "Imagem excedeu o tamanho máximo permitido de 2 MB!");
                            return PartialView("_EditMovieManager", filme);
                        }
                        ModelState.AddModelError("Titulo", "Título do filme já cadastrado!");
                        return PartialView("_EditMovieManager", filme);
                    }
                    ModelState.AddModelError("UploadImage", "Arquivo não suportado!");
                    return PartialView("_EditMovieManager", filme);
                }
                ModelState.AddModelError("UploadImage", "Nenhuma imagem carregada!");
                return PartialView("_EditMovieManager", filme);
            }
            return PartialView("_EditMovieManager", filme);
        }

        [HttpGet]
        [Route("MovieManager/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var filme = _filmeAplicacao.ObterPorId(id);
            return PartialView("_DeleteMovieManager", filme);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("MovieManager/Delete/{id}")]
        public IActionResult DeleteConfirm(int id)
        {
            var filme = _filmeAplicacao.ProcurarComEspecificacao(new FilmeComSessoesEspecificacao(id)).FirstOrDefault();

            if (filme.Sessoes.Any())
            {
                ModelState.AddModelError("", "Exclusão não permitida! O filme selecionado está vinculado a uma sessão!");
                return PartialView("_DeleteMovieManager", filme);
            }
            _filmeAplicacao.Remover(id);
            Notify("Filme removido com sucesso.", "Informação ao usuário", Models.NotificationType.success);
            return PartialView("_DeleteMovieManager");
        }
    }
}