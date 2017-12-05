using BookShop.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.DAL
{
    public class BookShopContext : DbContext
    {
        public BookShopContext() : base("BookShopContext")
        {

        }

        static BookShopContext()
        {
            Database.SetInitializer<BookShopContext>(new BookShopInitializer());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Category> Caregories { get; set; }

    }
}