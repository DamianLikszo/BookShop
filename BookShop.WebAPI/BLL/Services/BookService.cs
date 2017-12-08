using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Enums;
using BookShop.WebAPI.Models;

namespace BookShop.WebAPI.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly BookShopContext _db;

        public BookService(BookShopContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> createQuery(ExtraCategory extraCategory, int category, string filtrValue)
        {
            var query = _db.Books.AsQueryable();
            query = query.Where(book => !book.IsDeleted);
            filtrValue = filtrValue.ToLower();

            if (extraCategory != ExtraCategory.None)
                this.queryAddExtraCategory(ref query, extraCategory);
            if (filtrValue != string.Empty)
                this.queryAddFiltrValue(ref query, filtrValue);
            if (category > 0)
                query = query.Where(book => category == book.Category.Id);

            query = query.OrderBy(book => book.Title);

            return query.ToList();
        }
        
        private void queryAddExtraCategory( ref IQueryable<Book> query, ExtraCategory extraCategory)
        {
            DateTime dateFrom, dateTo, dateNow = DateTime.Now;
            ;
            switch (extraCategory)
            {
                case ExtraCategory.Nowosci:
                    dateFrom = dateNow.AddDays(-14);
                    query = query.Where(book => book.DateAdded > dateFrom);
                    break;
                case ExtraCategory.Zapowiedzi:
                    dateFrom = dateNow;
                    dateTo = dateNow.AddDays(14);
                    query = query.Where(book => book.DateRelease > dateFrom && book.DateRelease <= dateTo);
                    break;
                case ExtraCategory.SuperOkazje:
                    query = query.Where(book => book.Opportunity);
                    break;
            }
        }

        private void queryAddFiltrValue(ref IQueryable<Book> query, string filtrValue)
        {
            query = query.Where(book => book.Title.ToLower().Contains(filtrValue) ||
                                        (book.Author.FirstName.ToLower() + " " + book.Author.LastName.ToLower()).Contains(filtrValue) ||
                                        (book.Author.LastName.ToLower() + " " + book.Author.FirstName.ToLower()).Contains(filtrValue) ||
                                        book.PublishingHouse.Name.ToLower().Contains(filtrValue)
            );
        }
    }
}