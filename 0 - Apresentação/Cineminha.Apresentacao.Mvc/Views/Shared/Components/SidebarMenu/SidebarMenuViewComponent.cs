using Microsoft.AspNetCore.Mvc;

namespace Cineminha.Apresentacao.Mvc.Views.Shared.Components.SidebarMenu
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}