using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalTourProject.DtoLayer.DTOs.CityDTO
{
    public class CityAddDto
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityCountry { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}
