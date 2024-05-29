using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.isActive = "/Dashboard/Index";
            return View();
        }
       
    }
}
