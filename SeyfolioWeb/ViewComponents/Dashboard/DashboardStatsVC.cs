using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.ViewComponents.Dashboard
{
   
    public class DashboardStatsVC : ViewComponent
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        SkillManager skillManager = new SkillManager(new EfSkillDal());


        public IViewComponentResult Invoke()
        {
            ViewBag.ExperienceCount = experienceManager.GetList().Count;
            ViewBag.PortfolioCount = portfolioManager.GetList().Count;
            ViewBag.ServiceCount = serviceManager.GetList().Count;
            ViewBag.SkillCount = skillManager.GetList().Count;

            return View();
        }
    }

}
