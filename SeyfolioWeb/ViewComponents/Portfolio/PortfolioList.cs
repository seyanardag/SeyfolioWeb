using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SeyfolioWeb.ViewComponents.Portfolio
{
    public class PortfolioList : ViewComponent
    {
            PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            return View(portfolioManager.GetList().Where(x=>x.Status==true).ToList());
        }
    }
}
