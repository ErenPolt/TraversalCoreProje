using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        //----------------------------------------------------------------------------------------------
       
        public IActionResult Index()//Rehberleri listeleme
        {
            var values = _guideService.TGetList();
            return View(values);
        }
        //-----------------------------------------------------------------------------------------------
        //Ekleme işlemi;
        
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            ModelState.Clear();//Validasyon mesajlarının türkçe gelmesi için gereklidir. Önbellekteki ingilice mesajları silecek ve bizim mesdajlarımız devreye girecek..
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);//Validasyon ekledik.
            if (result.IsValid)//Eğer durum geçerliyse;
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index", "Guide", new { area = "Admin" });//Ekleme işlemin, yap..
            }
            else//Fakat değilse;
            {
                foreach(var item in result.Errors)//Hata dön
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //property ismi ve mesajı dön
                }
                return View();
            }
            
        }
        //------------------------------------------------------------------------------------------------------
        //Düzenleme işlemi;
         
        [HttpGet]
        public ActionResult EditGuide(int id)
        {
            var values = _guideService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }
        //----------------------------------------------------------------------------------------------------------
        public IActionResult DeleteGuide(int id)
        {
           var value = _guideService.TGetById(id);
            _guideService.TDelete(value);
            return RedirectToAction("Index");
        }
        //----------------------------------------------------------------------------------------------------------
        //Aktif/Pasif Durumu

         
        public IActionResult ChangeToTrue(int id)//Durumu Aktife ÇEvir
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

      
        public IActionResult ChangeToFalse(int id)//Durumu pasife çevir
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index","Guide", new {area = "Admin"});
        }

    }
}
