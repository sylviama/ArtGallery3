namespace PhotoGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Arts", "uploadedUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Arts", new[] { "uploadedUser_Id" });
            AddColumn("dbo.Arts", "uploadedUser", c => c.String());
            DropColumn("dbo.Arts", "uploadedUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arts", "uploadedUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Arts", "uploadedUser");
            CreateIndex("dbo.Arts", "uploadedUser_Id");
            AddForeignKey("dbo.Arts", "uploadedUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
