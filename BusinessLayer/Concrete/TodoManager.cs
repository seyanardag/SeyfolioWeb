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
    public class TodoManager : ITodoService
    {
        IToDoDal _todoDal;

        public TodoManager(IToDoDal todoDal)
        {
            _todoDal = todoDal;
        }

        public ToDoEntity GetById(int id)
        {
            return _todoDal.GetById(id);
        }

        public List<ToDoEntity> GetList()
        {
            return _todoDal.GetList();
        }

        public void TAdd(ToDoEntity t)
        {
            _todoDal.Insert(t);
        }

        public void TDelete(ToDoEntity t)
        {
            _todoDal.Delete(t);
        }

        public List<ToDoEntity> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TSave()
        {
           _todoDal.Save();
        }

        public void TUpdate(ToDoEntity t)
        {
            _todoDal.Update(t);
        }
    }
}
