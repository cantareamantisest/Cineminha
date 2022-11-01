using Microsoft.AspNetCore.Mvc;

namespace Cineminha.Apresentacao.Mvc.Views.Shared.Components.SidebarBrand
{
    public class SidebarBrandViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}