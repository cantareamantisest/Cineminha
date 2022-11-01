using Cineminha.Apresentacao.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cineminha.Apresentacao.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public void Notify(string message, string title, NotificationType type)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = type.ToString(),
                type = type.ToString(),
                provider = "sweetAlert"
            };
            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }
    }
}
