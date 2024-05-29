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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDAL;

        public SocialMediaManager(ISocialMediaDal socialMediaDAL)
        {
            _socialMediaDAL = socialMediaDAL;
        }

        public SocialMedia GetById(int id)
        {
            return _socialMediaDAL.GetById(id);
        }

        public List<SocialMedia> GetList()
        {
            return _socialMediaDAL.GetList();
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaDAL.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediaDAL.Delete(t);
        }

        public List<SocialMedia> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TSave()
        {
            _socialMediaDAL.Save();
        }

        public void TUpdate(SocialMedia t)
        {
            _socialMediaDAL.Update(t);
        }
    }
}
