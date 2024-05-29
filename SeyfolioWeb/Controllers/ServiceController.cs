using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager ServiceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            ViewBag.isActive = "/Service/Index";
            return View(ServiceManager.GetList());
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            ServiceValidator validation = new ServiceValidator();
            ValidationResult validationResult = validation.Validate(service);

            if (validationResult.IsValid)
            {
                ServiceManager.TAdd(service);
                return RedirectToAction("Index", "Service");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(service);
            }

        }

        public IActionResult DeleteService(int id)
        {
            Service serviceToDel = ServiceManager.GetById(id);
            ServiceManager.TDelete(serviceToDel);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {

            Service serviceToUpdate = ServiceManager.GetById(id);

            return View(serviceToUpdate);
        }
        public IActionResult UpdateService(Service service)
        {

            ServiceValidator validation = new ServiceValidator();
            ValidationResult validationResult = validation.Validate(service);

            if (validationResult.IsValid)
            {
                ServiceManager.TUpdate(service);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(service);
            }


        }
    }
}
