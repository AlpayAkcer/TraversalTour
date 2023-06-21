using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class Newsletter
    {
        [Key]
        public int NewsletterID { get; set; }
        public string Mail { get; set; }
        public bool IsActive { get; set; }
    }
}
