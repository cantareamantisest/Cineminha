using Microsoft.AspNetCore.Mvc;

namespace Cineminha.Apresentacao.Mvc.Views.Shared.Components.Sidebar
{
    public class SidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}