using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoGallery.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PhotoGallery.DAL
{
    public class ArtRepository
    {
        public ArtContext Context { get; set; }
        public ArtRepository()
        {
            Context = new ArtContext();
        }

        public ArtRepository(ArtContext _context)
        {
            Context = _context;
        }


        /************read************/
        //public BuyerArtTable GetString()
        //{

        //    return Context.BuyerArtTable.FirstOrDefault(b => b.Buyer.BuyerId == 1);
        //}
        public List<Art> GetAllArts()
        {
            return Context.Arts.ToList();
        }

        public List<Artist> GetAllArtist()
        {
            return Context.Artists.ToList();
        }

        public Art GetOneArt(int id)
        {
            return Context.Arts.FirstOrDefault(a => a.ArtId == id);
        }

        //for PurchaseController -- Cart action
        public List<Art> InCartArt(string BuyerUserName)
        {
            return Context.BuyerArtTable.Where(ba => ba.Buyer.SystemUser.UserName == BuyerUserName && ba.InCart == true).Select(a=>a.Art).ToList();
        }

        //for PurchaseController -- PurchaseHistory action
        public List<Art> PurchaseHistory(string BuyerUserName)
        {
            return Context.BuyerArtTable.Where(ba => ba.Buyer.SystemUser.UserName == BuyerUserName && ba.Purchased == true).Select(a => a.Art).ToList();
        }

        //for ManageArtsController -- Index action
        public List<Art> UploadedArts(string UploaderUserName)
        {
            return Context.Arts.Where(a => a.uploadedUser.UserName == UploaderUserName).ToList();
        }


        /***********************create******************/

        //create new Art for ManageArtsController 
        public void CreateNewArt(string InputUserId, Art art)
        {
            ApplicationUser currentUser = Context.Users.FirstOrDefault(d => d.Id == InputUserId);
            art.uploadedUser = currentUser;
            Context.Arts.Add(art);
            Context.SaveChanges();
        }


        //(create a new art is already taken care of in ManageArtsContoller and its views)

        //For clicking "Add to cart"
        public void AddToCart(string InputUserId, int InputArtId)
        {
            BuyerArtTable newBuyerArt = new BuyerArtTable();

            //match the current art
            Art newArt = Context.Arts.FirstOrDefault(a => a.ArtId == InputArtId);
            newBuyerArt.Art = newArt;

            //match the buyer
            Buyer newOrExistBuyer = CreateNewBuyerIfBuyerDoesntExist(InputUserId);
            try
            {
                newBuyerArt.Buyer = newOrExistBuyer;
            }
            catch (SystemException)
            {

            }
            

            newBuyerArt.InCart = true;
            newBuyerArt.PurchaseDate = DateTime.Now;
            Context.BuyerArtTable.Add(newBuyerArt);
            Context.SaveChanges();
        }

        public Buyer CreateNewBuyerIfBuyerDoesntExist(string InputUserId)
        {
            Buyer thatBuyer= Context.Buyers.FirstOrDefault(b => b.SystemUser.Id == InputUserId);
            if(thatBuyer ==null)
            {
                Buyer newBuyer = new Buyer();
                ApplicationUser newUser = Context.Users.FirstOrDefault(u => u.Id == InputUserId);
                newBuyer.SystemUser = newUser;
                return newBuyer;
            }else
            {
                return thatBuyer;//existing buyer
            }
            
        }

        

        //delete
        //update
    }
}