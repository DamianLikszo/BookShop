namespace BookShop.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateRelease = c.DateTime(nullable: false),
                        Opportunity = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Title = c.String(),
                        AuthorId = c.Int(nullable: false),
                        CarrierId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        PublishingHouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Carriers", t => t.CarrierId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.PublishingHouses", t => t.PublishingHouseId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.CarrierId)
                .Index(t => t.CategoryId)
                .Index(t => t.PublishingHouseId);
            
            CreateTable(
                "dbo.Carriers",
                c => new
                    {
                        CarrierId = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CarrierId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.PublishingHouses",
                c => new
                    {
                        PublishingHouseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PublishingHouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublishingHouseId", "dbo.PublishingHouses");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Books", "CarrierId", "dbo.Carriers");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "PublishingHouseId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropIndex("dbo.Books", new[] { "CarrierId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.PublishingHouses");
            DropTable("dbo.Categories");
            DropTable("dbo.Carriers");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
