using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PhotoGallery.Models;

namespace PhotoGallery.DAL
{
    public class ArtContext: ApplicationDbContext
    {
        public virtual new DbSet<Art> Arts { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<BuyerArtTable> BuyerArtTable { get; set; }

    }
}