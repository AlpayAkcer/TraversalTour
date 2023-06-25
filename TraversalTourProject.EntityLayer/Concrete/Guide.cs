using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class Guide
    {
        [Key]
        public int GuideID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}
