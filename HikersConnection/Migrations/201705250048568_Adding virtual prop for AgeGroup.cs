namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingvirtualpropforAgeGroup : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Hikers", "AgeGroupID");
            AddForeignKey("dbo.Hikers", "AgeGroupID", "dbo.AgeGroups", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hikers", "AgeGroupID", "dbo.AgeGroups");
            DropIndex("dbo.Hikers", new[] { "AgeGroupID" });
        }
    }
}
