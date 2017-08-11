namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAplicationUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hikes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Hikes", "ApplicationUser_Id");
            AddForeignKey("dbo.Hikes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hikes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Hikes", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.Hikes", "ApplicationUser_Id");
        }
    }
}
