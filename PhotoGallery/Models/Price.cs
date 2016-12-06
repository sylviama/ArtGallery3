using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class Price
    {
        [Key]
        public int PriceChangeId { get; set; }
        [Required]
        public virtual Art Art { get; set; }
        [Required]
        public virtual DateTime PriceEffectiveDate { get; set; }
        [Required]
        public int ArtPrice { get; set; }


    }
}