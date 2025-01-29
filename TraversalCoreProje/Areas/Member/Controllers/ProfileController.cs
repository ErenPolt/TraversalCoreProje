using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);//İsme göre arama işlemi;
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.mail = values.Email;
            userEditViewModel.phonenumber = values.PhoneNumber;
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);//isme göre bul
           
            if(p.Image != null)//eğer null değilse;
            {
                var resource = Directory.GetCurrentDirectory();
                //kaynak = programın mevcut çalışma dizinini resource(kaynak)'e atama yaptık..

                var extension = Path.GetExtension(p.Image.FileName);
                // extension = dosyanın uzantısını(.jpg, .png, .txt) tutar...

                var imagename = Guid.NewGuid() + extension;
                //resim ismi = rastgele resim adı oluştur ve dosya uzatısı ekle. Yani "fotograf.jpg" gibi...

                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                //resmin kaydedileceği konum = kaynak + ilgili klasör + resim ismi..

                var stream = new FileStream(savelocation, FileMode.Create);
                //akış değeri = dosya ile verialışverişi yapan sınıf(FileStream) (dosyanın tam yolu , dosya modu.oluştur)

                await p.Image.CopyToAsync(stream);//akıştan gelen değere kopyala;
                user.ImageUrl = imagename;//Identity ile parametreden gelen resmi eşitler..
            }
            user.Name = p.name;
            user.Surname = p.surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)//işlem başarılıysa;
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();

        }
    }
}
