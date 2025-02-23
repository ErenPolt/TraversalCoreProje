using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
  public interface ICommentDal: IGenericDal<Comment>
    {
        List<Comment> GetListCommentWithDestination();//Yorum listesini getirme işlemi için ICommenyDal' da tanımlama yapıyoruz. EF kısmında çağırma işlemi yapacağız<z..
    }
}
