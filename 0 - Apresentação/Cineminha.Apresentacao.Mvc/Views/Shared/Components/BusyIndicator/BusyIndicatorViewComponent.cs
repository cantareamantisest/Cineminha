using Microsoft.AspNetCore.Mvc;

namespace Cineminha.Apresentacao.Mvc.Views.Shared.Components.BusyIndicator
{
    public class BusyIndicatorViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}