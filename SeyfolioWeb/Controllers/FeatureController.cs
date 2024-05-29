using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SeyfolioWeb.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IActionResult Index()
        {
            ViewBag.isActive = "/Feature/Index";
            return View(featureManager.GetList().FirstOrDefault());
        }
        public IActionResult UpdateFeature()
        {
           

            return View(featureManager.GetList().FirstOrDefault());
        }
        [HttpPost]
        public IActionResult UpdateFeature(Feature feature)
        {
            FeatureValidator validationRules = new FeatureValidator();
            ValidationResult validationResult = validationRules.Validate(feature);

            if(validationResult.IsValid)
            {
                featureManager.TUpdate(feature);
                return RedirectToAction(nameof(Index));
            } else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(feature);
            }

            
        }
    }
}
