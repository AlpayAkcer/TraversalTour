using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalTourProject.BusinessLayer.Abstract;

namespace TraversalTourProject.BusinessLayer.Concrete
{
    public class ExcelManager : IExcelService
    {
        //Excel servisin içerisindeki methodumuz
        public byte[] ExcelTurListesi<T>(List<T> t) where T : class
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Tur Listesi");
            workSheet.Cells["A1"].LoadFromCollection(t, true, OfficeOpenXml.Table.TableStyles.Light10);


            return excel.GetAsByteArray();
        }
    }
}
