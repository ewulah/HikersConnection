namespace HikersConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HikesOrganizer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Hikes", name: "ApplicationUser_Id", newName: "Organizer_Id");
            RenameIndex(table: "dbo.Hikes", name: "IX_ApplicationUser_Id", newName: "IX_Organizer_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Hikes", name: "IX_Organizer_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Hikes", name: "Organizer_Id", newName: "ApplicationUser_Id");
        }
    }
}
