using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyfolioWeb.Areas.Writer.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SeyfolioWeb.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    //[Route("Writer/{controller}/{action}")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel()
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                //Password = user.PasswordHash
            };
            return View(userEditViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UserEditViewModel userEditViewModel)
        {

           WriterUser user = await _userManager.FindByNameAsync(User.Identity.Name);


            if (!ModelState.IsValid)
            {
                return View(userEditViewModel);
            }


            if (userEditViewModel.ImageFile != null)
            {
                string resource = Directory.GetCurrentDirectory() + "/wwwroot/userImage/";
                string extension = Path.GetExtension(userEditViewModel.ImageFile.FileName);

                string imageName = Guid.NewGuid().ToString() + extension;

                var saveLocation = resource + imageName;

                using var stream = new FileStream(saveLocation,FileMode.Create);                

               await userEditViewModel.ImageFile.CopyToAsync(stream);
                user.ImageUrl = "/userImage/" + imageName; ;

            }
            user.Surname = userEditViewModel.Surname;
            user.Name = userEditViewModel.Name;
            user.Email = userEditViewModel.Email;

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);

            //Kullanıcı Username i değiştirdiyse;
            if (userEditViewModel.UserName != user.UserName)
            {
                user.UserName = userEditViewModel.UserName;
                var result1 = await _userManager.UpdateAsync(user);

                if (result1.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                return View(userEditViewModel);

            }

            //Kullanıcı Username i değiştirmediyse;
            user.UserName = userEditViewModel.UserName;
            var result2 = await _userManager.UpdateAsync(user);

            if (result2.Succeeded)
            {               
                return RedirectToAction("Index", "Announcement");
            }

            return View(userEditViewModel);
        }
    }
}
