using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace SeyfolioWeb.Areas.Writer.ViewComponents
{
    public class Last3Messages : ViewComponent
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public Last3Messages(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {          
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var incomingMessages = _writerMessageManager.GetWriterReceivedMessages(user.Email);
            var last3Messages = incomingMessages.OrderByDescending(x=>x.Date).Take(3).ToList();
            return View(last3Messages);
        }
    }
}
