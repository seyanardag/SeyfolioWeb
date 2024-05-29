using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SeyfolioWeb.ViewComponents.Dashboard
{
    public class DashboardUserMessageListVC : ViewComponent
    {
        //UserMessageManager _userMessageManager = new UserMessageManager(new EfUserMessageDal());
        public IViewComponentResult Invoke()
        {
            //var values = _userMessageManager.GetUserMessageWithUserService().Take(4).ToList();
            return View();
        }
    }
}

//TODO: Burayı ve bu ViewComponent in Components klasörü altındaki Default.cshtml dosyasını yoruma aldık, çünkü UserMessage ve User class larını ve Bunların BL ve DAL daki kodlamalarını silince bu sefer buralar hata verdi. Proje tamamlandıktan sonra Dark admin in Dashboard undaki mesajlar muhtemelen çalışmayacak.
