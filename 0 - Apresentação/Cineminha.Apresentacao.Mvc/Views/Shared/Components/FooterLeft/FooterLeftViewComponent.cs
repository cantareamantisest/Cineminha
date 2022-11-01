using Microsoft.AspNetCore.Mvc;

namespace Cineminha.Apresentacao.Mvc.Views.Shared.Components.FooterLeft
{
    public class FooterLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}