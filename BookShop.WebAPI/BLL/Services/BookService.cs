using System;
using System.Linq;
using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Enums;
using BookShop.WebAPI.Models;

namespace BookShop.WebAPI.BLL.Services
{
    public class BookService : IBookService
    {
        public IQueryable<Book> createQueryPrimary(BookShopContext db, ExtraCategory extraCategory, int category, string filtrValue)
        {
            DateTime dateFrom, dateTo, dateNow = DateTime.Now;
            var query = db.Books.AsQueryable();
            query = query.Where(book => !book.IsDeleted);
            filtrValue = filtrValue.ToLower();

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

            if (filtrValue != string.Empty)
            {
                query = query.Where(book => book.Title.ToLower().Contains(filtrValue) ||
                                            (book.Author.FirstName.ToLower() + " " + book.Author.LastName.ToLower()).Contains(filtrValue) ||
                                            (book.Author.LastName.ToLower() + " " + book.Author.FirstName.ToLower()).Contains(filtrValue) ||
                                            book.PublishingHouse.Name.ToLower().Contains(filtrValue)
                                            );
            }
            if (category > 0)
                query = query.Where(book => category == book.Category.Id);

            query = query.OrderBy(book => book.Title);

            return query;
        }
    }
}