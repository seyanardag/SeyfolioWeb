using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace SeyfolioWeb.ViewComponents.AdminTopNavbarLastMessages
{
    public class TopNavbarLastMessages:ViewComponent
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        //UserManager<WriterUser> _userManager;

        //public TopNavbarLastMessages(UserManager<WriterUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        public IViewComponentResult Invoke()
        {
            var receivedMessages = _writerMessageManager.GetWriterReceivedMessages("volcano@gmail.com");
            return View(receivedMessages.OrderByDescending(x=>x.Date).Take(3).ToList());
        }
    }
}
