using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalTourProject.BusinessLayer.Abstract
{
    public interface IExcelService
    {
        byte[] ExcelTurListesi<T>(List<T> t) where T : class;

    }
}
