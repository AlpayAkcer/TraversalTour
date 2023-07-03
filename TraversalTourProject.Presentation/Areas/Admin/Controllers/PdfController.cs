using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticKullanimi()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReport/" + "dosya.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            Paragraph paragraph = new Paragraph("PDF Traversal Raporu");
            document.Add(paragraph);
            document.Close();


            return File("/PDFReport/dosya.pdf", "application/pdf", "dosya.pdf");
        }

        public IActionResult StaticKullanimiTablo()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReport/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            PdfPTable pdfTable = new PdfPTable(3);

            pdfTable.AddCell("Misafir Adı");
            pdfTable.AddCell("Misafir Soyadı");
            pdfTable.AddCell("Misafir TC");

            pdfTable.AddCell("Alpay");
            pdfTable.AddCell("Akçer");
            pdfTable.AddCell("56869028846");

            pdfTable.AddCell("Francesca");
            pdfTable.AddCell("David");
            pdfTable.AddCell("99072599314");

            pdfTable.AddCell("Atlas");
            pdfTable.AddCell("Akçer");
            pdfTable.AddCell("12345678977");

            document.Add(pdfTable);
            document.Close();


            return File("/PDFReport/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
