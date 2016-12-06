namespace PhotoGallery.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PhotoGallery.Models;
    using PhotoGallery.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoGallery.DAL.ArtContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhotoGallery.DAL.ArtContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //var artist1 = new Artist { ArtistFirstName = "Sylvia", ArtistLastName = "Ma", ArtistBirthday = new DateTime(1988, 8, 27) };
            //var artist2 = new Artist { ArtistFirstName = "Kathy", ArtistLastName = "Liu", ArtistBirthday = new DateTime(1989, 11, 1) };

            //var art1 = new Art { ArtName = "LightOfMe", Artist = artist1, ArtType = "Photo", Dimension = "5472X3648", FormatType = "JPEG", Size = "3.8M", Link = "https://c6.staticflickr.com/9/8236/29716928445_577c00bfc4_z.jpg" };
            //var art2 = new Art { ArtName = "Alyssa", Artist = artist1, ArtType = "Photo", Dimension = "5472X3648", FormatType = "JPEG", Size = "13.8M", Link = "https://c3.staticflickr.com/6/5753/30504762770_627980a07d_z.jpg" };

            //context.Artists.AddOrUpdate(
            //    a => a.ArtistFirstName,
            //    artist1, artist2);

            //context.Arts.AddOrUpdate(
            //    a => a.ArtName,
            //    art1, art2
            //    );

            //context.Prices.AddOrUpdate(
            //    p => p.PriceChangeId,
            //    new Price { Art = art1, PriceEffectiveDate = new DateTime(2016, 11, 1), ArtPrice = 2 },
            //    new Price { Art = art2, PriceEffectiveDate = new DateTime(2016, 11, 2), ArtPrice = 12 }
            //    );
        }
    }
}
