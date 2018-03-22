namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameBooksandCategoriestoBookandCategory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Books", newName: "Book");
            RenameTable(name: "dbo.Categories", newName: "Category");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Category", newName: "Categories");
            RenameTable(name: "dbo.Book", newName: "Books");
        }
    }
}
