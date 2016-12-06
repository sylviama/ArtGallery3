namespace PhotoGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Buyers", "SystemUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Buyers", new[] { "SystemUser_Id" });
            AddColumn("dbo.Buyers", "SystemUserName", c => c.String());
            DropColumn("dbo.Buyers", "SystemUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buyers", "SystemUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Buyers", "SystemUserName");
            CreateIndex("dbo.Buyers", "SystemUser_Id");
            AddForeignKey("dbo.Buyers", "SystemUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
