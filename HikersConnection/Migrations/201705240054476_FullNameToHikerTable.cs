namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullNameToHikerTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hikes", "Notes", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hikes", "Notes", c => c.String());
        }
    }
}
