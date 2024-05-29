using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SeyfolioWeb.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DefaultController : Controller
    {    
        public IActionResult Index()
        {      
            return View();
        }     

    }

}
