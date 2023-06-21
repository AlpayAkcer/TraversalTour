using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }
        public string ClientName { get; set; }
        public string ClientComment { get; set; }
        public string ClientImage { get; set; }
        public bool IsActive { get; set; }
    }
}
