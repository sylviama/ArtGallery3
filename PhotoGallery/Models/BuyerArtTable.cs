using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class BuyerArtTable
    {
        [Key]
        public int BuyerArtId { get; set; }
        public Buyer Buyer { get; set; }
        public Art Art { get; set; }
        public bool InCart { get; set; }
        public bool Purchased { get; set; }
        public bool Returned { get; set; }
        public int PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}