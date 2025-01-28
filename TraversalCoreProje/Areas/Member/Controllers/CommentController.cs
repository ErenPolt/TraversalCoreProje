using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]//Areas kullanabimek için tanımlamamız lazım bu şekilde..
    [AllowAnonymous]//Otantike olsun
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
