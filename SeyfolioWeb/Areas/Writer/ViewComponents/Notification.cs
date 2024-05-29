using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyfolioWeb.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Announcement> values = announcementManager.GetList().OrderByDescending(x => x.Date).Take(3).ToList();
            return View(values);
        }
    }
}
