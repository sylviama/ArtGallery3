using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using PhotoGallery.DAL;
using PhotoGallery.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PhotoGallery.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Cart()
        {
            ArtRepository repo = new ArtRepository();
            ViewBag.InCartArts = repo.InCartArt(User.Identity.GetUserId());
            ViewBag.TotalPayment = repo.CalculateTotalPayment(User.Identity.GetUserId());
            ViewBag.TotalPaymentForStripe = ViewBag.TotalPayment * 100;
            return View();
        }



        public ActionResult PurchaseHistory()
        {
            ArtRepository repo = new ArtRepository();
            ViewBag.PurchaseHistory = repo.PurchaseHistory(User.Identity.GetUserId());
            return View();
        }

        public ActionResult ChangeToPurchased()
        {
            ArtRepository repo = new ArtRepository();
            List<Art> purchasedArts=repo.InCartArt(User.Identity.GetUserId());
            foreach(var art in purchasedArts)
            {
                repo.FromInCartToPurchased(User.Identity.GetUserId(), art.ArtId);
            }

            return RedirectToAction("PurchaseHistory");
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddToCart(int InputArtId)
        {
            ArtRepository repo = new ArtRepository();
            var inputUserId = User.Identity.GetUserId();
            ViewBag.message=repo.AddToCart(inputUserId, InputArtId);
            
            return RedirectToAction("Cart");
        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Purchase/Delete/5
        [HttpPost]
        public ActionResult Delete(int InputArtId)
        {
            ArtRepository repo = new ArtRepository();
            repo.RemoveArtFromCart(User.Identity.GetUserId(), InputArtId);

            return RedirectToAction("Cart");
        }

        // POST: Purchase/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        TODO: Add delete logic here

        //        return RedirectToAction("Cart");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
