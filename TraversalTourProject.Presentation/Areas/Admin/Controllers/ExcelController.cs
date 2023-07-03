using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TraversalTourProject.BusinessLayer.Abstract;
using TraversalTourProject.DataAccessLayer.Concrete;
using TraversalTourProject.Presentation.Models;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExcelController : Controller
    {

        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }


        //Bu List Excel alacağımız listeyi bize modele göre döndüren değerleri verir.
        public List<DestinationViewModel> DestinationList()
        {
            List<DestinationViewModel> destinationViewModels = new List<DestinationViewModel>();
            using (var c = new Context())
            {
                destinationViewModels = c.Destinations.Select(x => new DestinationViewModel
                {
                    City = x.City,
                    Capacity = x.Capacity,
                    DayNight = x.DayNight,
                    Price = x.Price
                }).ToList();

                return destinationViewModels;
            }
        }

        //ServiceExcel methodunun içerisinden çağırıyoruz. Method orada yazılı

        public IActionResult DestinationStaticExcelReport()
        {
            return File(_excelService.ExcelTurListesi(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TurListesi.xlsx");
        }
    }
}
