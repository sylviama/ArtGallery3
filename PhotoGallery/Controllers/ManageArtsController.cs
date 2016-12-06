using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhotoGallery.DAL;
using PhotoGallery.Models;
using Microsoft.AspNet.Identity;

namespace PhotoGallery.Controllers
{
    public class ManageArtsController : Controller
    {
        private ArtContext db = new ArtContext();

        // GET: ManageArts
        //only show the art user uploaded
        public ActionResult Index()
        {
            ArtRepository repo = new ArtRepository();
            return View(repo.UploadedArts(User.Identity.GetUserName()));
            
        }

        // GET: ManageArts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = db.Arts.Find(id);
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

        // GET: ManageArts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageArts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtId,ArtName,Link,ArtType,FormatType,Size,Dimension")] Art art)
        {
            if (ModelState.IsValid)
            {
                //add uploadedUser info when upload a new art
                ArtRepository repo = new ArtRepository();
                repo.CreateNewArt(User.Identity.GetUserId(), art);
                return RedirectToAction("Index");
            }

            return View(art);
        }

        // GET: ManageArts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = db.Arts.Find(id);
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

        // POST: ManageArts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtId,ArtName,Link,ArtType,FormatType,Size,Dimension")] Art art)
        {
            if (ModelState.IsValid)
            {
                db.Entry(art).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(art);
        }

        // GET: ManageArts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = db.Arts.Find(id);
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

        // POST: ManageArts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Art art = db.Arts.Find(id);
            db.Arts.Remove(art);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
