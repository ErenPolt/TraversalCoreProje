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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment entity)//Ekleme işlemi
        {
            _commentDal.Insert(entity);
        }

        public void TDelete(Comment entity)//Silme işlemi
        {
           _commentDal.Delete(entity);
        }

        public Comment TGetById(int id)//Id'ye göre işlem yapma
        {
           return _commentDal.GetById(id);
        }

        public List<Comment> TGetList()//Listeleme işlemi
        {
            return _commentDal.GetList();
        }

        public List<Comment> TGetDestinationById(int id)
        {
            return _commentDal.GetListByFilter(x=>x.DestinationId == id);//Id'ye göre Yorum
        }

        public void TUpdate(Comment entity)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetListCommentWithDestination()//Destination tablosnu admin sayfasında ilişki içinde; listelme işlemi..
        {
            return _commentDal.GetListCommentWithDestination();
        }
    }
}
