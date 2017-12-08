using BookShop.WebAPI.Models;
using BookShop.WebAPI.Enums;
using System.Collections.Generic;

namespace BookShop.WebAPI.BLL.Services
{
    interface IBookService
    {
        IEnumerable<Book> createQuery(ExtraCategory extraCategory, int category, string filtrValue);
    }
}
