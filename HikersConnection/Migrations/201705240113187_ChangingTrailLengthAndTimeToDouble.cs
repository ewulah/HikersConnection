namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingTrailLengthAndTimeToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trails", "Length", c => c.Double());
            AlterColumn("dbo.Trails", "HikingTime", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trails", "HikingTime", c => c.Int());
            AlterColumn("dbo.Trails", "Length", c => c.Int());
        }
    }
}
