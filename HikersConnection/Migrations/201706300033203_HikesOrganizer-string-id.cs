namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HikesOrganizerstringid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Hikes", name: "Organizer_Id", newName: "OrganizerId_Id");
            RenameIndex(table: "dbo.Hikes", name: "IX_Organizer_Id", newName: "IX_OrganizerId_Id");
            AddColumn("dbo.Hikes", "Organizer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hikes", "Organizer");
            RenameIndex(table: "dbo.Hikes", name: "IX_OrganizerId_Id", newName: "IX_Organizer_Id");
            RenameColumn(table: "dbo.Hikes", name: "OrganizerId_Id", newName: "Organizer_Id");
        }
    }
}
