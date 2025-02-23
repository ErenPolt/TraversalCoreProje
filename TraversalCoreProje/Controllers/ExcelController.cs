using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
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

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using(var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult StaticExcelReport()
        {

            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
            //ExcelPackage excel = new ExcelPackage();
            //var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            //workSheet.Cells[1, 1].Value = "Rota"; //cells[1,1] bu biri satır 1.sütun anlamına gelir..
            //workSheet.Cells[1, 2].Value = "Rehber";
            //workSheet.Cells[1, 3].Value = "Kontenjan";

            //workSheet.Cells[2, 1].Value = "Gürcistan Batum Turu";
            //workSheet.Cells[2, 2].Value = "Kadir Yıldız";
            //workSheet.Cells[2, 3].Value = "50";

            //workSheet.Cells[3, 1].Value = "Sırbistan - Makedonya Turu";
            //workSheet.Cells[3, 2].Value = "Zeynep Öztürk";
            //workSheet.Cells[3, 3].Value = "35";

            //var bytes = excel.GetAsByteArray();//Byte türüne dönüştür.
            //return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya2.xlsx");

        }

        public IActionResult DestinationExcelReport()
        {
            using(var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;//üstteki şehir,konaklama süresi, fiyat ve kapasite 1. satıra denk geldiği için; biz verileri 2. satıra yazacağız...
               foreach(var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;//rowCont dediğimiz şey 2. satırı temsil ediyor. Yani 2. satırın , 1. sütünuna city verisini getir.
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;//2.satır 2.sütun; konaklama süresi
                    workSheet.Cell(rowCount, 3).Value=item.Price;//2.satır 3.sütün; fiyat
                    workSheet.Cell(rowCount,4).Value= item.Capacity;//2.satır 4.sütun; kapasite
                   rowCount++;//rowCount satır syısını temsil ediyor. her ilgili veri girişinde bir satır aşağı olacak..
                }

               using(var Stream = new MemoryStream())
                {
                    workBook.SaveAs(Stream);
                    var content = Stream.ToArray();//Bellekteki veriyi byte ye dönüştürür.
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
    }
}
