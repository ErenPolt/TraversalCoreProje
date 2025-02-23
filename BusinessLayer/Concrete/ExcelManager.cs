using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] ExcelList<T>(List<T> t) where T : class
        {
            ExcelPackage excel = new ExcelPackage();//Bellekte boş bir Excel sayfası oluşturur.
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");//Excel dosyasına Sayfa1 adında yeni bir çalışma sayfası ekler.Bunu Worksheete atadık.
            workSheet.Cells["A1"].LoadFromCollection(t, true, OfficeOpenXml.Table.TableStyles.Light10);
            //Verilerin Excel sayfasında A1 hücresinden itibaren yerleştirileceğini belirtir. 
            //t: Listeden gelen veriler.
            //true: Listenin property isimlerini(örneğin Name, Age) başlık olarak kullanır.
            //OfficeOpenXml.Table.TableStyles.Light10: Hücrelere otomatik olarak Light10 stilini uygular(tablo biçimlendirmesi, başlık rengi vs.).

            return excel.GetAsByteArray();//Excel dosyasını geriye byte olarak döndür...
        }
    }
}
