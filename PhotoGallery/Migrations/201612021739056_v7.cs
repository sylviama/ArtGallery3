namespace PhotoGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        BuyerId = c.Int(nullable: false, identity: true),
                        Balance = c.Int(nullable: false),
                        SystemUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BuyerId)
                .ForeignKey("dbo.AspNetUsers", t => t.SystemUser_Id)
                .Index(t => t.SystemUser_Id);
            
            CreateTable(
                "dbo.BuyerArtTables",
                c => new
                    {
                        BuyerArtId = c.Int(nullable: false, identity: true),
                        InCart = c.Boolean(nullable: false),
                        Purchased = c.Boolean(nullable: false),
                        Returned = c.Boolean(nullable: false),
                        PurchasePrice = c.Int(nullable: false),
                        Art_ArtId = c.Int(),
                        Buyer_BuyerId = c.Int(),
                    })
                .PrimaryKey(t => t.BuyerArtId)
                .ForeignKey("dbo.Arts", t => t.Art_ArtId)
                .ForeignKey("dbo.Buyers", t => t.Buyer_BuyerId)
                .Index(t => t.Art_ArtId)
                .Index(t => t.Buyer_BuyerId);
            
            CreateTable(
                "dbo.BuyerArts",
                c => new
                    {
                        Buyer_BuyerId = c.Int(nullable: false),
                        Art_ArtId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Buyer_BuyerId, t.Art_ArtId })
                .ForeignKey("dbo.Buyers", t => t.Buyer_BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.Arts", t => t.Art_ArtId, cascadeDelete: true)
                .Index(t => t.Buyer_BuyerId)
                .Index(t => t.Art_ArtId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyerArtTables", "Buyer_BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.BuyerArtTables", "Art_ArtId", "dbo.Arts");
            DropForeignKey("dbo.Buyers", "SystemUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BuyerArts", "Art_ArtId", "dbo.Arts");
            DropForeignKey("dbo.BuyerArts", "Buyer_BuyerId", "dbo.Buyers");
            DropIndex("dbo.BuyerArts", new[] { "Art_ArtId" });
            DropIndex("dbo.BuyerArts", new[] { "Buyer_BuyerId" });
            DropIndex("dbo.BuyerArtTables", new[] { "Buyer_BuyerId" });
            DropIndex("dbo.BuyerArtTables", new[] { "Art_ArtId" });
            DropIndex("dbo.Buyers", new[] { "SystemUser_Id" });
            DropTable("dbo.BuyerArts");
            DropTable("dbo.BuyerArtTables");
            DropTable("dbo.Buyers");
        }
    }
}
