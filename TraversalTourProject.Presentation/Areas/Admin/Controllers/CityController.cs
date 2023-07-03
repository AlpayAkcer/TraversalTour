using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.EntityLayer.Concrete;
using TraversalTourProject.Presentation.Models;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {

        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetListAll());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.IsActive = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }


        //public IActionResult CityList()
        //{
        //    var jsonCity = JsonConvert.SerializeObject(cities);
        //    return Json(jsonCity);
        //}

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID = 1,
        //        CityName = "Üsküp",
        //        CityCountry="Makedonya",
        //        DayNight="4 Gece, 3 Gün",
        //        Price=3500
        //    },
        //    new CityClass
        //    {
        //        CityID = 2,
        //        CityName = "Roma",
        //        CityCountry="Italia",
        //        DayNight="4 Gece, 3 Gün",
        //        Price=3500
        //    },
        //    new CityClass
        //    {
        //        CityID = 3,
        //        CityName = "Amsterdam",
        //        CityCountry="Netherland",
        //        DayNight="4 Gece, 3 Gün",
        //        Price=3500
        //    },
        //    new CityClass
        //    {
        //        CityID = 4,
        //        CityName = "London",
        //        CityCountry="İngiltere",
        //        DayNight="4 Gece, 3 Gün",
        //        Price=3500
        //    }
        //};
    }
}

