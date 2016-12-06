using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoGallery.DAL;
using Microsoft.AspNet.Identity;

namespace PhotoGallery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ArtRepository repo = new ArtRepository();
            ViewBag.AllArts = repo.GetAllArts();
            return View();
        }

        public ActionResult Detail(int id)
        {
            ArtRepository repo = new ArtRepository();
            ViewBag.detail = repo.GetOneArt(id);
            return View();
        }

        

        
    }
}