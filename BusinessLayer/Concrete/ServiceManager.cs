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
    public class ServiceManager : IServiceService  //TODO : burada IServiceService ı implemente etmiş, 28. derste. 
    {
        IServiceDal _service;
        public ServiceManager(IServiceDal service)
        {
            _service = service;
        }

        public Service GetById(int id)
        {
           return _service.GetById(id);
        }

        public List<Service> GetList()
        {
           return _service.GetList();
        }

        public void TAdd(Service t)
        {
            _service.Insert(t);
        }

        public void TDelete(Service t)
        {
            _service.Delete(t);
        }

        public List<Service> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TSave()
        {
           _service.Save();
        }

        public void TUpdate(Service t)
        {
           _service.Update(t);
        }
    }
}
