using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Concrete
{
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDal _writerMessageDal;       

        public WriterMessageManager(IWriterMessageDal writerMessageDal)
        {
            _writerMessageDal = writerMessageDal;            
        }

        public WriterMessage GetById(int id)
        {
            return _writerMessageDal.GetById(id);
        }

        public List<WriterMessage> GetList()
        {
            return _writerMessageDal.GetList();
        }
        //TODO: GetWriterReceivedMessages ve GetWriterSentMessages metodları kullanıldı, çönceden tanımlanan ve hem business hem de DAL katmanındaki TGetListByFilter metotlarının abstract ve implementasyonları proje sonunda hala kullanılmazsa silebilirsin. 


        public List<WriterMessage> GetWriterReceivedMessages(string receiverEmail)
        {
            return _writerMessageDal.GetByFilter(x => x.Receiver == receiverEmail);
        }

        public List<WriterMessage> GetWriterSentMessages(string senderEmail)
        {
            return _writerMessageDal.GetByFilter(x=>x.Sender == senderEmail);
        }
       

        public void TAdd(WriterMessage t)
        {
            _writerMessageDal.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            _writerMessageDal.Delete(t);
        }

        public List<WriterMessage> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterMessage t)
        {
            _writerMessageDal.Update(t);
        }
    }
}
