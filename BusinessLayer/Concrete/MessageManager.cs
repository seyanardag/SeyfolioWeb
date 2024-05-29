﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
           return _messageDal.GetById(id);
        }

        public List<Message> GetList()
        {
            return _messageDal.GetList();
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public List<Message> TGetListByFilter()
        {            
            throw new NotImplementedException();
        }

        public void TSave()
        {
            _messageDal.Save();
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);  
        }
    }
}
