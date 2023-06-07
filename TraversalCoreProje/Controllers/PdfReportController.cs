using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);//sayfa formatı
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();

            return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya2.pdf");


           
        }
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya3.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);//sayfa formatı
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Mahmut Gazi");
            pdfPTable.AddCell("Altun");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("Mahmut ");
            pdfPTable.AddCell("Altun");
            pdfPTable.AddCell("22222222222");

            pdfPTable.AddCell(" Gazi");
            pdfPTable.AddCell("Altun");
            pdfPTable.AddCell("33333333333");

            document.Add(pdfPTable);
            document.Close();

            return File("/pdfreports/dosya3.pdf", "application/pdf", "dosya3.pdf");
        }
    }
}
