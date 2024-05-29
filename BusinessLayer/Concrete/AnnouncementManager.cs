using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcement;

        public AnnouncementManager(IAnnouncementDal announcement)
        {
            _announcement = announcement;
        }

        public Announcement GetById(int id)
        {
            return _announcement.GetById(id);  
        }

        public List<Announcement> GetList()
        {
            return _announcement.GetList();
        }

        public void TAdd(Announcement t)
        {
           _announcement.Insert(t);
        }

        public void TDelete(Announcement t)
        {
            _announcement.Delete(t);
        }

        public List<Announcement> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Announcement t)
        {
            _announcement.Update(t);
        }
    }
}
