using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeyfolioWeb.Areas.Writer.Models;
using System.Threading.Tasks;

namespace SeyfolioWeb.Areas.Writer.Controllers
{
    [Area("Writer")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            //if (ModelState.IsValid)
            //{
            WriterUser writerUser = new WriterUser()
            {
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                Email = userRegisterViewModel.Mail,
                UserName = userRegisterViewModel.UserName,
                ImageUrl = userRegisterViewModel.ImageUrl
            };

            if (userRegisterViewModel.Password == userRegisterViewModel.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(writerUser, userRegisterViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("modelHatasi", item.Description);
                    }
                    ModelState.AddModelError("ModelErrors", "Kayıt işlemi başarısız oldu.");
                }
            }
          

            //}
            //else
            //{

            return View(userRegisterViewModel);

            //}

            //TODO : burada ModelState isvaild e gerek olmayabilir, ama yapılacak 2 şey var, 1. Buranın UI tarafını düzenle, 2. UI daki checkbox onayını buraya entegre et.
            //return View(userRegisterViewModel);
        }

    }
}
