using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace PhotoGallery.Models
{
    public class Art
    {
        [Key]
        public int ArtId { get; set; }
        [Required]
        public string ArtName { get; set; }
        public string Link { get; set; }
        public string ArtType { get; set; }
        public string FormatType { get; set; }
        public string Size { get; set; }
        public string Dimension { get; set; }
        public int CurrentPrice { get; set; }
        public virtual Artist Artist { get; set; }

        public virtual ApplicationUser uploadedUser { get; set; }

        public virtual List<Buyer> buyerList { get; set; }
    }
}