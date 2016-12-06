using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class Buyer
    {
        [Key]
        public int BuyerId { get; set; }
        public ApplicationUser SystemUser { get; set; }
        public List<Art> PurchasedArt { get; set; }
        public int Balance { get; set; }
    }
}