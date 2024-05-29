using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SeyfolioWeb.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public IActionResult Index()
        {
            ViewBag.isActive = "/About/Index";
            return View(aboutManager.GetList().FirstOrDefault());
        }
        public IActionResult UpdateAbout()
        {
            ViewBag.isActive = "/About/Index";
            return View(aboutManager.GetList().FirstOrDefault());
        }
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            AboutValidator validationRules = new AboutValidator();
            ValidationResult validationResult = validationRules.Validate(about);

            if (validationResult.IsValid)
            {
                aboutManager.TUpdate(about);
                return RedirectToAction("Index","About");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(about);
            }


        }
    }
}
