using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactUsDal: IGenericDal<ContactUs>
    {
        List<ContactUs> GetListContactUsByTrue();//True olanlar
        List<ContactUs> GetListContactUsByFalse();//False olanlar
        void ContactUsStatusChangeToFalse(int id);//False Yap
    }
}
