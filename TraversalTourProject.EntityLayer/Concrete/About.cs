using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalTourProject.EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool MainView { get; set; }
        public bool IsActive { get; set; }
    }
}
