namespace BookShop.WebAPI.Migrations
{
    using BookShop.WebAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShop.WebAPI.DAL.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookShop.WebAPI.DAL.BookShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var Carriers = new List<Carrier>
            {
                new Carrier() { Id = 1, Name = "PenDrive" },
                new Carrier() { Id = 2, Name = "p造ta CD" },
                new Carrier() { Id = 3, Name = "p造ta DVD" }
            };
            Carriers.ForEach(item => context.Carriers.AddOrUpdate(item));
            context.SaveChanges();

            var Categories = new List<Category>
            { 
                new Category() { Id = 1, Name = "Audiobooki" },
                new Category() { Id = 2, Name = "E-booki" }
            };
            Categories.ForEach(item => context.Caregories.AddOrUpdate(item));
            context.SaveChanges();

            var PublishingHouses = new List<PublishingHouse>
            {
                new PublishingHouse() { Id = 1, Name = "Z這te Julki"},
                new PublishingHouse() { Id = 2, Name = "Srebne ptaki"},
                new PublishingHouse() { Id = 3, Name = "Nie dla idiot闚"},
                new PublishingHouse() { Id = 4, Name = "Karpaty"},
                new PublishingHouse() { Id = 5, Name = "Worki i piachy"},
                new PublishingHouse() { Id = 6, Name = "Parki"},
                new PublishingHouse() { Id = 7, Name = "Z這te υdzie"},
                new PublishingHouse() { Id = 8, Name = "Julian i przygody"},
                new PublishingHouse() { Id = 9, Name = "Usuni皻e 1", IsDeleted = true },
                new PublishingHouse() { Id = 10, Name = "Usuni皻e 2", IsDeleted = true },
            };
            PublishingHouses.ForEach(item => context.PublishinHouses.AddOrUpdate(item));
            context.SaveChanges();

            var Authors = new List<Author>
            {
                new Author() { Id = 1, FirstName = "Julian", LastName = "Kujawa" },
                new Author() { Id = 2, FirstName = "Karol", LastName = "Witka" },
                new Author() { Id = 3, FirstName = "Maciek", LastName = "Pluszak" },
                new Author() { Id = 4, FirstName = "Kuba", LastName = "Kwiatek" },
                new Author() { Id = 5, FirstName = "ㄆkasz", LastName = "Leniwiec" },
                new Author() { Id = 6, FirstName = "Karolina", LastName = "Cizoenk" },
                new Author() { Id = 7, FirstName = "Kamil", LastName = "Warty豉" },
                new Author() { Id = 8, FirstName = "Agnieszka", LastName = "Gagatek" },
                new Author() { Id = 9, FirstName = "Daniel", LastName = "Mi造" },
                new Author() { Id = 10, FirstName = "Micha�", LastName = "Z造" },
                new Author() { Id = 11, FirstName = "Usuni皻y", LastName = "Usuni皻y", IsDeleted = true },
                new Author() { Id = 12, FirstName = "Usuni皻y", LastName = "Usuni皻y", IsDeleted = true }
            };
            Authors.ForEach(item => context.Authors.AddOrUpdate(item));
            context.SaveChanges();

            var Books = new List<Book>()
            {
                 new Book() { Id = 1, AuthorId = 1,  CategoryId = 1, DateAdded = new DateTime(2017, 5, 10, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 1, Title = "Najlepsze dania" },
                 new Book() { Id = 2, AuthorId = 2,  CategoryId = 2, DateAdded = new DateTime(2017, 1, 11, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 2, Title = "Koty" },
                 new Book() { Id = 3, AuthorId = 3,  CategoryId = 1, DateAdded = new DateTime(2017, 2, 12, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = true, Price = 13, PublishingHouseId = 3, Title = "Psy" },
                 new Book() { Id = 4, AuthorId = 4,  CategoryId = 1, DateAdded = new DateTime(2017, 3, 13, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 4, Title = "Koty i Psy" },
                 new Book() { Id = 5, AuthorId = 5,  CategoryId = 1, DateAdded = new DateTime(2017, 5, 14, 8, 30, 5), DateRelease = new DateTime(2017, 12, 10, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 5, Title = "Dania dla kota" },
                 new Book() { Id = 6, AuthorId = 6,  CategoryId = 2, DateAdded = new DateTime(2017, 6, 15, 8, 30, 5), DateRelease = new DateTime(2016, 12, 11, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 6, Title = "Dania dla psa" },
                 new Book() { Id = 7, AuthorId = 7,  CategoryId = 1, DateAdded = new DateTime(2017, 7, 16, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = true, Price = 14, PublishingHouseId = 7, Title = "Zbawy z psem" },
                 new Book() { Id = 8, AuthorId = 8,  CategoryId = 2, DateAdded = new DateTime(2017, 8, 17, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 8, Title = "Zabawy z kotem" },
                 new Book() { Id = 9, AuthorId = 9,  CategoryId = 1, DateAdded = new DateTime(2017, 9, 18, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 1, Title = "Praca w IT" },
                 new Book() { Id = 10, AuthorId = 10,  CategoryId = 1, DateAdded = new DateTime(2017, 3, 1, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = true, Price = 11, PublishingHouseId = 3, Title = "Programowanie" },
                 new Book() { Id = 11, AuthorId = 11,  CategoryId = 1, DateAdded = new DateTime(2017, 2, 1, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = false, Price = 122, PublishingHouseId = 3, Title = "C# w pigu販e" },
                 new Book() { Id = 12, AuthorId = 12,  CategoryId = 1, DateAdded = new DateTime(2017, 2, 2, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 3, Title = "Szybko i 豉two" },
                 new Book() { Id = 13, AuthorId = 1,  CategoryId = 2, DateAdded = new DateTime(2017, 3, 11, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 1, Title = "Najlepsze Obrazy" },
                 new Book() { Id = 14, AuthorId = 2,  CategoryId = 1, DateAdded = new DateTime(2017, 4, 1, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = true, Price = 13, PublishingHouseId = 2, Title = "Najlepsze 獞iczenia na si這wni" },
                 new Book() { Id = 15, AuthorId = 1,  CategoryId = 1, DateAdded = new DateTime(2017, 5, 1, 8, 30, 5), DateRelease = new DateTime(2016, 6, 1, 8, 30, 52), Opportunity = false, Price = 17, PublishingHouseId = 1, Title = "Bieganie ranem" },
                 new Book() { Id = 16, AuthorId = 1,  CategoryId = 2, DateAdded = new DateTime(2017, 6, 23, 8, 30, 5), DateRelease = new DateTime(2018, 6, 1, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 1, Title = "Maraton" },
                 new Book() { Id = 17, AuthorId = 1,  CategoryId = 1, DateAdded = new DateTime(2017, 2, 1, 8, 30, 5), DateRelease = new DateTime(2018, 6, 1, 8, 30, 52), Opportunity = true, Price = 12, PublishingHouseId = 2, Title = "Dwa oblicza" },
                 new Book() { Id = 18, AuthorId = 2,  CategoryId = 1, DateAdded = new DateTime(2017, 11, 1, 8, 30, 5), DateRelease = new DateTime(2018, 6, 1, 8, 30, 52), Opportunity = true, Price = 15, PublishingHouseId = 1, Title = "Najlepsze gry komputerowe" },
                 new Book() { Id = 19, AuthorId = 2,  CategoryId = 2, DateAdded = new DateTime(2017, 3, 1, 8, 30, 5), DateRelease = new DateTime(2018, 6, 1, 8, 30, 52), Opportunity = true, Price = 13, PublishingHouseId = 5, Title = "Logika dla leniwych" },
                 new Book() { Id = 20, AuthorId = 1,  CategoryId = 1, DateAdded = new DateTime(2017, 4, 12, 8, 30, 5), DateRelease = new DateTime(2018, 6, 1, 8, 30, 52), Opportunity = false, Price = 11, PublishingHouseId = 3, Title = "Gdzie kupi� mieszkanie" },
                 new Book() { Id = 21, AuthorId = 3,  CategoryId = 1, DateAdded = new DateTime(2017, 5, 1, 8, 30, 5), DateRelease = new DateTime(2018, 6, 1, 8, 30, 52), Opportunity = false, Price = 12, PublishingHouseId = 1, Title = "Usuni皻e", IsDeleted = true }
             };
             Books.ForEach(item => context.Books.AddOrUpdate(item));
             context.SaveChanges();
             
        }
    }
}
