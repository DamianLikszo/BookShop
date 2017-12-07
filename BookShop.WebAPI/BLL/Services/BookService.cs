using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Models;
using static BookShop.WebAPI.Controllers.BooksController;

namespace BookShop.WebAPI.BLL.Services
{
    public class BookService : IBookService
    {
        public IQueryable<Book> createQuery(BookShopContext db, Additional additional, int category, string filtrValue = "")
        {
            DateTime dateFrom, dateTo, dateNow = DateTime.Now;
            var query = db.Books.AsQueryable();
            query = query.Where(book => !book.IsDeleted);
            filtrValue.ToLower();

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

            if (filtrValue != "")
            {
                query = query.Where(book => book.Title.ToLower().Contains(filtrValue) ||
                                            (book.Author.FirstName.ToLower() + " " + book.Author.LastName.ToLower()).Contains(filtrValue) ||
                                            (book.Author.LastName.ToLower() + " " + book.Author.FirstName.ToLower()).Contains(filtrValue)
                                            );
            }
            if (category > 0)
                query = query.Where(book => category == book.CategoryId);

            return query;
        }

        public IEnumerable<BookDTO> mapBooks(IEnumerable<Book> books)
        {
            List<BookDTO> booksDTO = new List<BookDTO>();
            foreach (Book book in books)
            {
                booksDTO.Add(new BookDTO(book));
            }

            return booksDTO;
        }
    }
}