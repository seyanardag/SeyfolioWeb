using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager _socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            ViewBag.isActive = "/SocialMedia/Index";
            return View(_socialMediaManager.GetList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.isActive = "/SocialMedia/Index";
            return View();
        }
        [HttpPost]
        public IActionResult Add(SocialMedia socialMedia)
        {
            _socialMediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.isActive = "/SocialMedia/Index";
            
            return View(_socialMediaManager.GetById(id));
        }
        [HttpPost]
        public IActionResult Update(SocialMedia socialMedia)
        {
            _socialMediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            SocialMedia valueToDel = _socialMediaManager.GetById(id);
            _socialMediaManager.TDelete(valueToDel);
            return RedirectToAction("Index");
        }
    }
}
