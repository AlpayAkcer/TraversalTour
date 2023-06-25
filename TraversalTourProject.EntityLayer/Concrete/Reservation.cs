using System;
using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public string PersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }
        public Status Status { get; set; }
        public bool IsActive { get; set; }
    }
}
