using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal: IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id);//Onay bekleyen rezervasyonlar
        List<Reservation> GetListWithReservationByAccepted(int id);//Onaylanan rezervasyonlar
        List<Reservation> GetListWithReservationByPrevious(int  id);//Geçmiş rezervasyonlar
    }
}
