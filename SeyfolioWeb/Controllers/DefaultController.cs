using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SeyfolioWeb.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.isActive = "/Default/Index";
            return View();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

       
    }
}
