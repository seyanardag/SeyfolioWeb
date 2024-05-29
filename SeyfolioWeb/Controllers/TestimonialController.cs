using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.Controllers
{
    public class TestimonialController : Controller
    {
        
        TestimonialManager _testimonialManager = new TestimonialManager(new EfTestimonialDal());

     
        public IActionResult Index()
        {
            ViewBag.isActive = "/Testimonial/Index";
            return View(_testimonialManager.GetList());
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            ViewBag.isActive = "/Testimonial/Index";

            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial param)
        {

            _testimonialManager.TAdd(param);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteTestimonial(int id)
        {
            Testimonial testimonialToDel = _testimonialManager.GetById(id);
            _testimonialManager.TDelete(testimonialToDel);

            return RedirectToAction("Index");
        }

        [HttpGet] 
        public IActionResult UpdateTestimonial(int id)
        {
            ViewBag.isActive = "/Testimonial/Index";
            return View(_testimonialManager.GetById(id));
        }
        [HttpPost] 
        public IActionResult UpdateTestimonial(Testimonial param)
        {
            _testimonialManager.TUpdate(param);
            return RedirectToAction("Index");
        }



    }
}
