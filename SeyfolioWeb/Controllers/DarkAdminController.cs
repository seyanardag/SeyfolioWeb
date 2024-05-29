using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.Controllers
{
    public class DarkAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
