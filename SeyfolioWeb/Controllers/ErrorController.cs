using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage401()
        {
            return View();
        }
    }
}
