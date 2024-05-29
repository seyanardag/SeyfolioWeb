using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyfolioWeb.ViewComponents.Dashboard
{
    public class DashboardTodoVC : ViewComponent
    {
        TodoManager TodoManager = new TodoManager(new EfToDoDal());
        public IViewComponentResult Invoke()
        {
            return View(TodoManager.GetList());
        }
    }
}
