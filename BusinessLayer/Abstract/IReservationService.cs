using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService: IGenericService<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id);//onay bekleyen rezervasyonları; şartlı getirme işlemi..
        List<Reservation> GetListWithReservationByAccepted(int id);//onaylanan rezervasyonları; şartlı getirme işlemi..
        List<Reservation> GetListWithReservationByPrevious(int id);//geçmiş rezervasyonları; şartlı getirme işlemi..
       
    }
}
