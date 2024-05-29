using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyfolioWeb.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> SentMessages()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageList = writerMessageManager.GetWriterSentMessages(user.Email);
            return View(messageList);
        }
        public async Task<IActionResult> ReceivedMessages()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messageList = writerMessageManager.GetWriterReceivedMessages(user.Email);
            return View(messageList);
        }
        [HttpGet]
        public async Task<IActionResult> MessageDetail(int id)
        {

            //MessageDetails de geri butonu gelen mesajlara mı gidecek giden mesajlara mı? bunun belirlenmesi için;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receivedMessageList = writerMessageManager.GetWriterReceivedMessages(user.Email);

            if(receivedMessageList.Select(x => x.WriterMessageId).ToList().Contains(id))
            {
                ViewBag.BakcTo = "ReceivedMessages";
            }
            else
            {
                ViewBag.BakcTo = "SentMessages";
            }



            return View(writerMessageManager.GetById(id));
        }
        [HttpGet]
        public async Task< IActionResult> SendMessage()
        {
            var users = _userManager.Users.ToList();
            var usernamesAndEmails = users.Select(x=> new { Display = $"{x.Name}  {x.Surname}  --> eposta:[{x.Email}]", Value = x.Email } ).ToList();
            SelectList emailSelectList = new SelectList(usernamesAndEmails,"Value", "Display");
                       
            ViewData["UserEmails"] = emailSelectList;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage writerMessage)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            writerMessage.Sender=user.Email;
            writerMessage.SenderName=user.Name + " " + user.Surname;
            writerMessage.Date = DateTime.Now;

            Context context= new Context();
            writerMessage.ReceiverName = context.Users.Where(x=>x.Email == writerMessage.Receiver).Select( y=> y.Name + " " + y.Surname ).FirstOrDefault();

            writerMessageManager.TAdd(writerMessage);
            return RedirectToAction("SentMessages");
        }

        public async Task<IActionResult> DeleteSentMessage(int ID)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            //Mesajın login yapan user a ait olduğunun kontrolü
            int delMessageId= writerMessageManager.GetList().Where(x=>x.Sender == user.Email && x.WriterMessageId == ID).Select(x=>x.WriterMessageId).FirstOrDefault();
                        
            var messageToDel = writerMessageManager.GetById(delMessageId);

            if (messageToDel == null)
            {
                return BadRequest();
            } else
            {
                writerMessageManager.TDelete(messageToDel);
                return RedirectToAction("SentMessages", "Message");
            }

        }



        public async Task<IActionResult> DeleteReceivedMessage(int ID)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            //Mesajın login yapan user a ait olduğunun kontrolü
            int delMessageId = writerMessageManager.GetList().Where(x => x.Receiver == user.Email && x.WriterMessageId == ID).Select(x => x.WriterMessageId).FirstOrDefault();

            var messageToDel = writerMessageManager.GetById(delMessageId);

            if (messageToDel == null)
            {
                return BadRequest();
            }
            else
            {
                writerMessageManager.TDelete(messageToDel);
                return RedirectToAction("ReceivedMessages", "Message");
            }

        }


    }
}
