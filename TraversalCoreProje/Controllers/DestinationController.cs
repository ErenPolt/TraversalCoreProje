using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()//Destination Listelenmesi
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
        //-------------------------------------------------------------------------------------------
        //Detaylar;
        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {
            return View();
        }
        //-------------------------------------------------------------------------------------------------
    }
}
