using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About> , IAboutDal //TODO: Not; burada IAboutDal eklemesek de normalde çalışır ama sadece About ile ilgili bir işlem vs ekleneceği zaman donu uygulayabilmek için eklendi. 16. derste bahsetmiş.
    {
    }
}
