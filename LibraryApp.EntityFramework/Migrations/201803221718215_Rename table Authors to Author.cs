namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenametableAuthorstoAuthor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Authors", newName: "Author");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Author", newName: "Authors");
        }
    }
}
