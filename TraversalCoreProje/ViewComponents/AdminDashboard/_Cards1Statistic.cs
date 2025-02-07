using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic: ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Destinations.Count();//Tur sayısı
            ViewBag.v2 = c.Users.Count();//Kişi sayısı
            return View();
        }
    }
}
