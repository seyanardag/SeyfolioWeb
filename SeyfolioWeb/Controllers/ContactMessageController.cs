using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SeyfolioWeb.Controllers
{
    public class ContactMessageController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());

        public IActionResult Index()
        {
            return View(_messageManager.GetList());
        }


        [HttpPost]
        public IActionResult SendMessage(Message message)
        {

            message.Date = DateTime.Now;
            message.Status = true;
            _messageManager.TAdd(message);

            return RedirectToAction(nameof(Index), "Default");
        }

        public IActionResult DeleteMessage(int id)
        {
            Message messageToDel = _messageManager.GetById(id);
            _messageManager.TDelete(messageToDel);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int id)
        {
            return View(_messageManager.GetById(id));
        }
        //TODO: Mesaj status alanı zaten var, bunu kullanarak mesajın okunma durumu ayarlanabilir.
    }
}
