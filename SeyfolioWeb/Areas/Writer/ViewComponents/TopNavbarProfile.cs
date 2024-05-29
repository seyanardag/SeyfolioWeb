using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SeyfolioWeb.Areas.Writer.ViewComponents
{
    public class TopNavbarProfile : ViewComponent
    {
        private readonly UserManager<WriterUser> _usermanager;

        public TopNavbarProfile(UserManager<WriterUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _usermanager.FindByNameAsync(User.Identity.Name);
            
            
            return View(user);
        }
    }
}
