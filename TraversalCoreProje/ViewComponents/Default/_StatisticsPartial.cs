using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _StatisticsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count();//Toplam Rotalar
            ViewBag.v2 = c.Guides.Count();//Toplam Rehberler
            ViewBag.v3 = "285";
            return View();
        }
    }
}
