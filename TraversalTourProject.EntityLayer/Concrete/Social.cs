using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class Social
    {
        [Key]
        public int SocialID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string CssIcon { get; set; }
        public bool IsActive { get; set; }
    }
}
