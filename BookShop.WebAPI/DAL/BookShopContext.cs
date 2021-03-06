﻿using BookShop.WebAPI.Models;
using System.Data.Entity;

namespace BookShop.WebAPI.DAL
{
    public class BookShopContext : DbContext
    {
        public BookShopContext() : base("BookShopContext")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Category> Caregories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PublishingHouse> PublishinHouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.DateAdded)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Book>()
                .Property(b => b.DateRelease)
                .HasColumnType("datetime2");

            // Relacje
            modelBuilder.Entity<Book>()
                .HasRequired<Author>(b => b.Author)
                .WithMany(a => a.Books);

            modelBuilder.Entity<Book>()
                .HasRequired<Category>(b => b.Category)
                .WithMany(c => c.Books);

            modelBuilder.Entity<Book>()
                .HasRequired<PublishingHouse>(b => b.PublishingHouse)
                .WithMany(p => p.Books);

            // Indeksy
            // ... 

            base.OnModelCreating(modelBuilder);
        }

    }
}