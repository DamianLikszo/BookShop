using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookShop.WebAPI.Controllers.BooksController;

namespace BookShop.WebAPI.BLL.Services
{
    interface IBookService
    {
        IQueryable<Book> createQueryPrimary(BookShopContext db, Additional additional, int category, string filtrValue);
        IQueryable<Book> createQueryTitleOnly(BookShopContext db, string title);
        IQueryable<Book> createQueryCategoryOnly(BookShopContext db, string category);
        IQueryable<Book> createQueryPublishingHouseOnly(BookShopContext db, string publishingHouse);
    }
}
