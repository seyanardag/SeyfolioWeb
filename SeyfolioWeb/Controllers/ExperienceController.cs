using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.Controllers
{
    [Authorize (Roles ="Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            ViewBag.isActive = "/Experience/Index";

            return View(experienceManager.GetList());
        }
        [HttpGet]
        public IActionResult AddExperience()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {

            ExperienceValidator validations = new ExperienceValidator();
            ValidationResult validationResult = validations.Validate(experience);

            if (validationResult.IsValid)
            {

                experienceManager.TAdd(experience);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(experience);
            }

        }


        public IActionResult DeleteExperience(int id)
        {
            Experience experienceToDel = experienceManager.GetById(id);
            experienceManager.TDelete(experienceToDel);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            Experience experienceToUpdate = experienceManager.GetById(id);
            return View(experienceToUpdate);
        }

        public IActionResult UpdateExperience(Experience experience)
        {
            ExperienceValidator validations = new ExperienceValidator();
            ValidationResult validationResult = validations.Validate(experience);

            if (validationResult.IsValid)
            {
                experienceManager.TUpdate(experience);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(experience);
            }

        }
    }
}
