namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SplittingdataandtimeinHike : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hikes", "Time", c => c.String(nullable: false));
            AlterColumn("dbo.Hikes", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hikes", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Hikes", "Time");
        }
    }
}
