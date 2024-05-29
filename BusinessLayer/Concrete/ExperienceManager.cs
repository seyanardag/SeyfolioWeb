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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public Experience GetById(int id)
        {
           return _experienceDal.GetById(id);
        }

        public List<Experience> GetList()
        {
            return _experienceDal.GetList();
        }

        public void TAdd(Experience t)
        {
           _experienceDal.Insert(t);
        }

        public void TDelete(Experience t)
        {
           _experienceDal.Delete(t);
        }

        public List<Experience> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TSave()
        {
            _experienceDal.Save();
        }

        public void TUpdate(Experience t)
        {
           _experienceDal.Update(t);
        }
    }
}
