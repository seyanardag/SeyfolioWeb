using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyfolioWeb.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
       private readonly UserManager<WriterUser> _userManager;

        public AdminMessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> SentMessages()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            

            ViewBag.isActive = "/AdminMessage/SentMessages";
            var messages = _writerMessageManager.GetWriterSentMessages(user.Email);
            return View(messages);
        }

        public async Task<IActionResult> ReceivedMessages()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
           
            ViewBag.isActive = "/AdminMessage/ReceivedMessages";
            var messages = _writerMessageManager.GetWriterReceivedMessages(user.Email);
            return View(messages);
        }
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var messageToDel = _writerMessageManager.GetById(id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var sentMessageIDs = _writerMessageManager.GetWriterSentMessages(user.Email).Select(x=>x.WriterMessageId);
            if (sentMessageIDs.Contains(messageToDel.WriterMessageId))
            {
                _writerMessageManager.TDelete(messageToDel);
                return RedirectToAction("SentMessages");

            } else {
                _writerMessageManager.TDelete(messageToDel);
                return RedirectToAction("ReceivedMessages");
            }
             
        }

        public IActionResult MessageDetail(int id)
        {        
            return View(_writerMessageManager.GetById(id));
        }


        //TODO: Aşağıda mesaj gönderirken e-posta sistemde kayıtlı olmayan birine ait ise validasyon dan döndürülmesi sağlanabilir.
        //TODO: Ayrıca sistemde aynı e-pota adresi birden fazla kişiye aitse yukarıda _userManager.FindByNameAsync(User.Identity.Name) metodu hata döndürüyor, sisteme ilk kayıtta e-postaların unique olmasının kontrolünü identity yapmıyorsa biz yapmalıyız.

        public IActionResult AdminSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminSendMessage(WriterMessage param)
        {            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            param.Date = DateTime.Now;
            param.Sender = user.Email;
            param.SenderName = user.UserName;

            var receiverData = await _userManager.FindByEmailAsync(param.Receiver);
            param.ReceiverName = receiverData.Name + " " + receiverData.Surname;

            _writerMessageManager.TAdd(param);

            return RedirectToAction("SentMessages");
        }
        


    }
}
