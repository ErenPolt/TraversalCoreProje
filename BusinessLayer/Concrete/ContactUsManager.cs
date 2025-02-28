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
    public class ContactUsManager : IContactUsService
    {
        private readonly IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void TAdd(ContactUs entity)//Ekleme
        {
            _contactUsDal.Insert(entity);
        }

        public void TContactUsStatusChangeToFalse(int id)//False Yap
        {
            throw new NotImplementedException();
        }

        public void TDelete(ContactUs entity)//Silme İşlemi
        {
            throw new NotImplementedException();
        }

        public ContactUs TGetById(int id)//Id'ye göre 
        {
           return _contactUsDal.GetById(id);
        }

        public List<ContactUs> TGetList()//Listeleme 
        {
           return _contactUsDal.GetList();
        }

        public List<ContactUs> TGetListContactUsByFalse()//False Olanları listele
        {
           return _contactUsDal.GetListContactUsByFalse();
        }

        public List<ContactUs> TGetListContactUsByTrue()//True olanalrı listele
        {
           return _contactUsDal.GetListContactUsByTrue();
        }

        public void TUpdate(ContactUs entity)//Güncelleme
        {
           _contactUsDal.Update(entity);
        }
    }
}
