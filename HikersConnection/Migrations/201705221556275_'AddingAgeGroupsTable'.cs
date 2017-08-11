namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAgeGroupsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Group = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AgeGroups");
        }
    }
}
