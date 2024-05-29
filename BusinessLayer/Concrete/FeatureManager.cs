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
    public class FeatureManager : IGenericService<Feature>  //TODO : Burada yanlışlık mı var?
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public Feature GetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public List<Feature> GetList()
        {
            return _featureDal.GetList();
        }

        public void TAdd(Feature t)
        {
            _featureDal.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureDal.Delete(t);
        }

        public List<Feature> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TSave()
        {
            _featureDal.Save();
        }

        public void TUpdate(Feature t)
        {
            _featureDal.Update(t);
        }
    }
}
