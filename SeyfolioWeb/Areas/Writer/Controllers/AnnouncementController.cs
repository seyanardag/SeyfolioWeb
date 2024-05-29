using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class AnnouncementController : Controller
    {

        AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementDal());
                
        //[Authorize]
        public IActionResult Index()
        {
            string res1 = AnnouncementStatus.Bitti.ToString();
            string res2 = AnnouncementStatus.DevamEdiyor.ToString();
            



            return View(_announcementManager.GetList());
        }
        public IActionResult AnnouncementDetail(int id)
        {
            return View(_announcementManager.GetById(id));
        }
    }
}
