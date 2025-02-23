using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller//Pdf Raporları..
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);//Dökümanın oluşturulması. Paratez içinde; A4'ten sonra (virgül ile sağdan ve soldan kenar boşluğunu belirleyebiliriz.. )

            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");//Paragraf oluşturma

            document.Add(paragraph);//Dökümanın içine paragraftan gelen değeri ekle
            
            document.Close();

            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);//Dökümanın oluşturulması. Paratez içinde; A4'ten sonra (virgül ile sağdan ve soldan kenar boşluğunu belirleyebiliriz.. )

            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);//Sütun değeri 3

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir Tc");

            pdfPTable.AddCell("Mert");
            pdfPTable.AddCell("Atmaz");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("İbrahim");
            pdfPTable.AddCell("Polat");
            pdfPTable.AddCell("22222222222");

            pdfPTable.AddCell("Tugay");
            pdfPTable.AddCell("İduğ");
            pdfPTable.AddCell("33333333333");

            document.Add(pdfPTable);
            document.Close();

            return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
