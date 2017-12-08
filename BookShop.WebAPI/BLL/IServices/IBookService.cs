using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Models;
using System.Linq;
using BookShop.WebAPI.Enums;

namespace BookShop.WebAPI.BLL.Services
{
    interface IBookService
    {
        IQueryable<Book> createQueryPrimary(BookShopContext db, ExtraCategory extraCategory, int category, string filtrValue);
    }
}
