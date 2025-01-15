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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
            _aboutDal.Insert(entity);//Ekleme işlemi
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);//Silme işlemi
        }

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList();//Listeleme işlemi
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);//Güncelleme işlemi
        }
    }
}
