using Microsoft.AspNetCore.Mvc;

namespace Cineminha.Apresentacao.Mvc.Views.Shared.Components.HeaderRight
{
    public class HeaderRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}