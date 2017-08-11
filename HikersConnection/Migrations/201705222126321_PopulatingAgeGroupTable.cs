namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingAgeGroupTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trails", "DogFriendly", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trails", "DogFriendly", c => c.Boolean());
        }
    }
}
