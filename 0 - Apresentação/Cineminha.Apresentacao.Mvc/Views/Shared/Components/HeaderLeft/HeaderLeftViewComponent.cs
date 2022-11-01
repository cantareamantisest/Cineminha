using Microsoft.AspNetCore.Mvc;

namespace Cineminha.Apresentacao.Mvc.Views.Shared.Components.HeaderLeft
{
    public class HeaderLeftViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}