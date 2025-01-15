using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class DefaultController : Controller//Anasayfa
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
