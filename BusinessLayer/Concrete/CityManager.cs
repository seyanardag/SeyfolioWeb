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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public Cities GetById(int id)
        {
           return _cityDal.GetById(id);
        }

        public List<Cities> GetList()
        {
            return _cityDal.GetList();
        }

        public void TAdd(Cities t)
        {
            _cityDal.Insert(t);
        }

        public void TDelete(Cities t)
        {
            _cityDal.Delete(t);
        }

        public List<Cities> TGetListByFilter()
        {
            throw new NotImplementedException();

        }

        public void TUpdate(Cities t)
        {
            _cityDal.Update(t);
        }
    }
}
