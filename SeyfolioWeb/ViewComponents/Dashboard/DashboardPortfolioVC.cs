using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace SeyfolioWeb.ViewComponents.Dashboard
{
    public class DashboardPortfolioVC : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            ViewBag.aktifProjeSayisi = portfolioManager.GetList().Where(x=>x.Status==true).Count();
            ViewBag.pasifProjeSayisi = portfolioManager.GetList().Where(x => x.Status == false).Count();


            ViewBag.projeTmm0_35 = portfolioManager.GetList().Where(x => x.CompletionValue <=35).Count();
            ViewBag.projeTmm36_70 = portfolioManager.GetList().Where(x => x.CompletionValue > 35).Where(x=>x.CompletionValue <=70).Count();
            ViewBag.projeTmm71_99 = portfolioManager.GetList().Where(x => x.CompletionValue > 70).Where(x => x.CompletionValue <= 99).Count();
            ViewBag.projeTmm100 = portfolioManager.GetList().Where(x => x.CompletionValue == 100).Count();
          

            return View(portfolioManager.GetList());
        }
    
    }
}
