﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult MyCurrentReservation()//Aktif Rezervasyonar
        {
            return View();
        }
        //------------------------------------------------------------------------------------------------
        public IActionResult MyOldReservation()//Eski Rezervasyonar
        {
            return View();
        }
        //-------------------------------------------------------------------------------------------------
        public async Task<IActionResult> MyApprovalReservation()//Onay Bekleyen Rezervasyonlar
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListApprovalReservation(values.Id);
            return View(valuesList);
        }
        //-------------------------------------------------------------------------------------------------

        //Rezervasyon oluşturma;
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()//Destination için dropdownlist kullancağız...
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = 5;
            p.Status = "Onay Bekliyor";
            reservationManager.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
        //-----------------------------------------------------------------------------------------------------
    }
}
