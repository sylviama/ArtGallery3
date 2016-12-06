using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [Required]
        public string ArtistFirstName { get; set; }
        public string ArtistLastName { get; set; }
        public virtual DateTime ArtistBirthday { get; set; }
        public virtual List<Art> ArtList { get; set; }
    }
}