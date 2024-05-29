using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SeyfolioWeb.Controllers
{
    public class ContactInfoController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        public IActionResult Index()
        {
            ViewBag.isActive = "/ContactInfo/Index";
            return View(_contactManager.GetList().FirstOrDefault());
        }
        public IActionResult UpdateContactInfo()
        {
            ViewBag.isActive = "/ContactInfo/Index";
            return View(_contactManager.GetList().FirstOrDefault());
        }
        [HttpPost]
        public IActionResult UpdateContactInfo(Contact contact)
        {

            ContactInfoValidator validationRules = new ContactInfoValidator();
            ValidationResult validationResult = validationRules.Validate(contact);


            if (validationResult.IsValid)
            {
                _contactManager.TUpdate(contact);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(contact);
            }


        }
    }
}
