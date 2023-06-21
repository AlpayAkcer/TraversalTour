using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class SubAbout
    {
        [Key]
        public int SubAboutID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}
