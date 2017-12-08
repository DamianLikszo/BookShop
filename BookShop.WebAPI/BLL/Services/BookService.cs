using System;
using System.Linq;
using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Models;
using static BookShop.WebAPI.Controllers.BooksController;

namespace BookShop.WebAPI.BLL.Services
{
    public class BookService : IBookService
    {
        public IQueryable<Book> createQueryPrimary(BookShopContext db, Additional additional, int category, string filtrValue)
        {
            DateTime dateFrom, dateTo, dateNow = DateTime.Now;
            var query = db.Books.AsQueryable();
            query = query.Where(book => !book.IsDeleted);
            filtrValue = filtrValue.ToLower();

            switch (additional)
            {
                case Additional.Nowosci:
                    dateFrom = dateNow.AddDays(-14);
                    query = query.Where(book => book.DateAdded > dateFrom);
                    break;
                case Additional.Zapowiedzi:
                    dateFrom = dateNow;
                    dateTo = dateNow.AddDays(14);
                    query = query.Where(book => book.DateRelease > dateFrom && book.DateRelease <= dateTo);
                    break;
                case Additional.SuperOkazje:
                    query = query.Where(book => book.Opportunity);
                    break;
            }

            if (filtrValue != string.Empty)
            {
                query = query.Where(book => book.Title.ToLower().Contains(filtrValue) ||
                                            (book.Author.FirstName.ToLower() + " " + book.Author.LastName.ToLower()).Contains(filtrValue) ||
                                            (book.Author.LastName.ToLower() + " " + book.Author.FirstName.ToLower()).Contains(filtrValue)
                                            );
            }
            if (category > 0)
                query = query.Where(book => category == book.Category.Id);

            query = query.OrderBy(book => book.Title);

            return query;
        }

        public IQueryable<Book> createQueryCategoryOnly(BookShopContext db, string category)
        {
            category = category.ToLower();
            return db.Books.Where(book => !book.IsDeleted && book.Category.Name.ToLower().Contains(category)).OrderBy(book => book.Category.Name);
        }

        public IQueryable<Book> createQueryPublishingHouseOnly(BookShopContext db, string publishingHouse)
        {
            publishingHouse = publishingHouse.ToLower();
            return db.Books.Where(book => !book.IsDeleted && book.PublishingHouse.Name.ToLower().Contains(publishingHouse))
                           .OrderBy(book => book.PublishingHouse.Name);
        }

        public IQueryable<Book> createQueryTitleOnly(BookShopContext db, string title)
        { 
            title = title.ToLower();
            return db.Books.Where(book => !book.IsDeleted && book.Title.ToLower().Contains(title)).OrderBy(book => book.Title);
        }
    }
}