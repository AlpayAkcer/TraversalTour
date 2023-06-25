using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
