using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SeyfolioWeb.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            FeatureManager featureManager= new FeatureManager(new EfFeatureDal());
             
            return View(featureManager.GetList().FirstOrDefault());
        }
    }
}
