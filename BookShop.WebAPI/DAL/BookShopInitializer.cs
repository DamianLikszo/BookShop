using BookShop.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.DAL
{
    public class BookShopInitializer : DropCreateDatabaseAlways<BookShopContext>
    {
        protected override void Seed(BookShopContext context)
        {
            SeedBookShopDate(context);

            base.Seed(context);
        }

        private void SeedBookShopDate(BookShopContext context)
        {
            var Carriers = new List<Carrier>
            {
                new Carrier() { CarrierId = 1, Name = "PenDrive" }
            };
            Carriers.ForEach(item => context.Carriers.Add(item));
            context.SaveChanges();

            var Categories = new List<Category>
            {
                // x^2
                new Category() { CategoryId = 1, Name = "Wszystkie" }
            };
            Categories.ForEach(item => context.Caregories.Add(item));
            context.SaveChanges();

            var Books = new List<Book>()
            {
                new Book() { BookId = 1, Autor = "Tadeusz Kember",  CategoryId = 1, DateAdded = DateTime.Now, DateRelease = DateTime.Now, Opportunity = false, Price = 12, PublishingHouse = "Wydawnictwo Zielona Kiszka", Title = "Najlepsze dania" }
            };
            Books.ForEach(item => context.Books.Add(item));
            context.SaveChanges();
        }
    }
}