﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        //----------------------------------------------------------------------------------------------------------
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();//Rotaları listeleme;
            return View(values);
        }
        //-------------------------------------------------------------------------------------------------------------
        //Ekleme işlemi;
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destinationManager.TAdd(destination);
            return RedirectToAction("Index");
        }
        //-------------------------------------------------------------------------------------------------------------------
        //Silme işlemi;
        public IActionResult DeleteDestination(int id)
        {
            var values = destinationManager.TGetById(id);
            destinationManager.TDelete(values);
            return RedirectToAction("Index");

        }
        //---------------------------------------------------------------------------------------------------------------------
        //Güncelleme işlemi;
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = destinationManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            destinationManager.TUpdate(destination);
            return RedirectToAction("Index");
        }
        //-----------------------------------------------------------------------------------------------------------------------
    }
}
