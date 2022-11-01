using Microsoft.AspNetCore.Mvc;

namespace Cineminha.Apresentacao.Mvc.Views.Shared.Components.FooterRight
{
    public class FooterRightViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}