﻿using BookShop.WebAPI.Models;
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
        public DbSet<Author> Authors { get; set; }
        public DbSet<PublishingHouse> PublishinHouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Relacje
            modelBuilder.Entity<Book>()
                .HasRequired<Author>(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuhtorId);

            modelBuilder.Entity<Book>()
                .HasRequired<Category>(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Book>()
                .HasRequired<Carrier>(b => b.Carrier)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CarrierId);

            modelBuilder.Entity<Book>()
                .HasRequired<PublishingHouse>(b => b.PublishingHouse)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublishingHouseId);

            // Indeksy
            // ... 

            base.OnModelCreating(modelBuilder);
        }

    }
}