using System.Collections.Generic;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id);
        List<Reservation> GetListWithReservationByAccepted(int id);
        List<Reservation> GetListWithReservationByPrevious(int id);


    }
}
