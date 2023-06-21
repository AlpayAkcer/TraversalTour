using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class Featured2
    {
        [Key]
        public int Featured2ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}
