using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);//Ekleme metotu
        void TDelete(T entity);//Silme metotu
        void TUpdate(T entity);//Güncelleme
        List<T> TGetList();//Listeleme
        T TGetById(int id);//Id'ye göre işlem
    }
}
