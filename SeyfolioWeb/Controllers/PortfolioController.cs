using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.isActive = "/Portfolio/Index";
           
            return View(portfolioManager.GetList());
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult results = validationRules.Validate(portfolio);
            if(results.IsValid)
            {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction(nameof(Index));
            } else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(portfolio);

          
        }

        public IActionResult DeletePortfolio(int id)
        {
            Portfolio portfolioToDel = portfolioManager.GetById(id);
            portfolioManager.TDelete(portfolioToDel);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            ViewBag.value1 = "Proje Düzenle";
            ViewBag.value2 = "Proje";
            ViewBag.value3 = "Proje Düzenle";

            Portfolio portfolioToUpdate = portfolioManager.GetById(id);


            return View(portfolioToUpdate);

        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {

            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult validationResult = validationRules.Validate(portfolio);

            if (validationResult.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction(nameof(Index));
            } else
            {
                return View(portfolio);
            }
        }
    }
}
