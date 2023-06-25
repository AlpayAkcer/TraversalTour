using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string Name { get; set; }
        public bool IsAtive { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
