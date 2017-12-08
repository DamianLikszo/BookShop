namespace BookShop.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixrelacje : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_Id");
            RenameColumn(table: "dbo.Books", name: "CategoryId", newName: "Category_Id");
            RenameColumn(table: "dbo.Books", name: "PublishingHouseId", newName: "PublishingHouse_Id");
            RenameIndex(table: "dbo.Books", name: "IX_AuthorId", newName: "IX_Author_Id");
            RenameIndex(table: "dbo.Books", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameIndex(table: "dbo.Books", name: "IX_PublishingHouseId", newName: "IX_PublishingHouse_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_PublishingHouse_Id", newName: "IX_PublishingHouseId");
            RenameIndex(table: "dbo.Books", name: "IX_Category_Id", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.Books", name: "IX_Author_Id", newName: "IX_AuthorId");
            RenameColumn(table: "dbo.Books", name: "PublishingHouse_Id", newName: "PublishingHouseId");
            RenameColumn(table: "dbo.Books", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Books", name: "Author_Id", newName: "AuthorId");
        }
    }
}
