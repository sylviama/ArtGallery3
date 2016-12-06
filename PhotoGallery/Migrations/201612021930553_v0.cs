namespace PhotoGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arts", "uploadedUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Buyers", "SystemUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Arts", "uploadedUser_Id");
            CreateIndex("dbo.Buyers", "SystemUser_Id");
            AddForeignKey("dbo.Buyers", "SystemUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Arts", "uploadedUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Arts", "uploadedUser");
            DropColumn("dbo.Buyers", "SystemUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buyers", "SystemUserName", c => c.String());
            AddColumn("dbo.Arts", "uploadedUser", c => c.String());
            DropForeignKey("dbo.Arts", "uploadedUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Buyers", "SystemUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Buyers", new[] { "SystemUser_Id" });
            DropIndex("dbo.Arts", new[] { "uploadedUser_Id" });
            DropColumn("dbo.Buyers", "SystemUser_Id");
            DropColumn("dbo.Arts", "uploadedUser_Id");
        }
    }
}
