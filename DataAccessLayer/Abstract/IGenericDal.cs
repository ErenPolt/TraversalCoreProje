using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>//T; bizim entiy'lerimizi temsil ediyor..
    {
        void Insert(T entity);//Ekleme Metodu;
        void Delete(T entity);//Silme Metodu;
        void Update(T entity);//Güncelleme Metodu;
        List<T> GetList();//Listeleme Metodu;
    }
}
