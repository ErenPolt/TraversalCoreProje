﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
       //------------------------------------------------------------------------------------------------------------
       //Yorum ekleme işlemi;
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.i = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Commentstate = true; 
            commentManager.TAdd(p);
            return RedirectToAction("Index", "Destination");
        }
        //---------------------------------------------------------------------------------------------------------------
        
    }
}
