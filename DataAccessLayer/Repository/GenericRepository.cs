using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class//GenericRepository,dışarıdan bir T entitysi alsın: IgenericDal'dan miras al. O da bir T değeri alsın.
                                                                      //T değeri ise; bir class olsun..
    {
        public void Delete(T entity)//Silme işlemi
        {
            using var c = new Context();
            c.Remove(entity);
            c.SaveChanges();
        }

        public List<T> GetList()//Listeleme işlemi
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Insert(T entity)//Ekleme işlemi
        {
            using var c = new Context();
            c.Add(entity);
        }

        public void Update(T entity)//Güncelleme işlemi
        {
            using var c = new Context();
            c.Update(entity);
        }
    }
}
