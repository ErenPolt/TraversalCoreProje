using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }
        //------------------------------------------------------------------------------------------------------------
        public IActionResult Index()//Listeleme işlemi
        {
            var values = _appUserService.TGetList();
            return View(values);
        }
        //----------------------------------------------------------------------------------------------------------------- 
        public IActionResult DeleteUse(int id)//Silme işlemi;
        {
            var values = _appUserService.TGetById(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }
        //-----------------------------------------------------------------------------------------------------------------
        //Güncelleme işlemi

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values =_appUserService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //Yorumları listeleme işlemi;
        public IActionResult CommentUser(int id)
        {
            
            return View();
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        //Tur geçmişi listeleme; Yani onaylanann...
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
