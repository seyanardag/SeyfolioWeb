using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SeyfolioWeb.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.isActive = "/Skill/Index";
            return View(skillManager.GetList());
        }

        [HttpGet]
        public IActionResult AddSkill()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {        
            //SkillValidator validator = new SkillValidator();

            ValidationResult validationResult = new SkillValidator().Validate(skill);

            if(validationResult.IsValid)
            {
                skillManager.TAdd(skill);
                return RedirectToAction(nameof(Index));
            } else {

                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(skill); 
            }

        }

        public IActionResult DeleteSkill(int id)
        {
            Skill skillToDel =  skillManager.GetById(id);
            skillManager.TDelete(skillToDel);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
           
            Skill skillToUpdate = skillManager.GetById(id);           

            return View(skillToUpdate);
        }
        public IActionResult UpdateSkill(Skill skill)
        {        
            
            SkillValidator validation = new SkillValidator();
            ValidationResult validationResult = validation.Validate(skill);

            if(validationResult.IsValid)
            {
                skillManager.TUpdate(skill);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(skill);
            }


        }
    }
}
