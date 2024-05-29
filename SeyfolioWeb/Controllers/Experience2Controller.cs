using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SeyfolioWeb.Controllers
{
    public class Experience2Controller : Controller
    {

        ExperienceManager _experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            ViewBag.isActive = "/Experience2/Index";
            return View();
        }
        public IActionResult ListExperience()
        {
            var serialized = JsonConvert.SerializeObject(_experienceManager.GetList());
            return Json(serialized);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience param)
        {
            _experienceManager.TAdd(param);
            var values = JsonConvert.SerializeObject(param);

            return Json(values);
        }

        public IActionResult GetById(int ExperienceIdx)
        {
            var foundExp = _experienceManager.GetById(ExperienceIdx);
            var serialized = JsonConvert.SerializeObject(foundExp);
            return Json(serialized);
        }

        public IActionResult DeleteById(int id)
        {
            var expToDel = _experienceManager.GetById(id);
            _experienceManager.TDelete(expToDel);
            return NoContent();
        }


    }
}
