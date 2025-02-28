using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
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

        public IActionResult CityList()//Listeleme
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());//Newtonsoft.Json kütüphanesini kullanarak; cities'i JSON string formatına dönüştür ve jsonCity değişkenine yaz..
            return Json(jsonCity);//ve Json olarak döndür.
        }
        //-----------------------------------------------------------------------------------------------------------
        //Ekleme işlemi:
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Image = "test";
            destination.Description = "test";
            destination.CoverImage = "test";
            destination.Details1 = "test";
            destination.Details2 = "test";
            destination.Image2 = "test";
            destination.Status = true;

            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }
        //-----------------------------------------------------------------------------------------------------------
        //Id'ye göre getirme:
        public IActionResult GetById(int DestinationId)
        {
            var values = _destinationService.TGetById(DestinationId);
            var jsonvalues = JsonConvert.SerializeObject(values);
            return Json(jsonvalues); 
        }
        //---------------------------------------------------------------------------------------------------------
        //Silme işlemi:
        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetById(id);
            _destinationService.TDelete(values);
            return NoContent();
        }
        //--------------------------------------------------------------------------------------------------------------
        //Güncelleme işlemi;
        public IActionResult UpdateCity(Destination destination)
        {
            //var values = _destinationService.TGetById(destination.DestinationId);
            destination.Image = "test";
            destination.Description = "test";
            destination.CoverImage = "test";
            destination.Details1 = "test";
            destination.Details2 = "test";
            destination.Image2 = "test";
            destination.Status = true;
            _destinationService.TUpdate(destination);
            var jsonvalues = JsonConvert.SerializeObject(destination);
            return Json(jsonvalues);
        }
        //--------------------------------------------------------------------------------------------------------------------------------


        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityId = 1,
        //        CityName = "Üsküp",
        //        CityCountry = "Makedonya"
        //    },

        //    new CityClass
        //    {
        //        CityId= 2,
        //        CityName = "Roma",
        //        CityCountry = "İtalya"
        //    },

        //    new CityClass   
        //    {
        //        CityId = 3,
        //        CityName = "Londra",
        //        CityCountry = "İngiltere"
        //    }
        //};
    }
}
