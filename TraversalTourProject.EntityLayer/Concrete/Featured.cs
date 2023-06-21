using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class Featured
    {
        [Key]
        public int FeaturedID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }

    }
}
