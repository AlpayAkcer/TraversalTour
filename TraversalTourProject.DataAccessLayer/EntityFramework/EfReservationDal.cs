using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TraversalTourProject.DataAccessLayer.Abstract;
using TraversalTourProject.DataAccessLayer.Concrete;
using TraversalTourProject.DataAccessLayer.Repository;
using TraversalTourProject.EntityLayer.Concrete;

namespace TraversalTourProject.DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                //Onaylandı
                return context.Reservations.Include(x => x.Destination).Where(x => x.StatusID == 2 && x.AppUserID == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                //Tamamlandı
                return context.Reservations.Include(x => x.Destination).Where(x => x.StatusID == 13 && x.AppUserID == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.StatusID == 1 && x.AppUserID == id).ToList();
            }
        }
    }
}
