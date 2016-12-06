using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotoGallery.DAL;
using PhotoGallery.Models;
using Microsoft.AspNet.Identity;

namespace PhotoGallery.Controllers
{
    public class ArtApiController : ApiController
    {
        // GET: api/ArtApi
        //public BuyerArtTable Get()
        //{
        //    ArtRepository repo = new ArtRepository();
        //    //return "value";
        //    return repo.GetString();
        //}

        // GET: api/ArtApi/5
        public Art Get(int id)
        {
            ArtRepository repo = new ArtRepository();
            return repo.GetOneArt(id);
        }

        // POST: api/ArtApi
        public void Post([FromBody]int InputArtId)
        {
            ArtRepository repo = new ArtRepository();
            var inputUserId = User.Identity.GetUserId();
            repo.AddToCart(inputUserId, InputArtId);
        }

        // PUT: api/ArtApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ArtApi/5
        public void Delete(int id)
        {
        }
    }
}
