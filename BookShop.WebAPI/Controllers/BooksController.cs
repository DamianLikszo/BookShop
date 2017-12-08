using BookShop.WebAPI.BLL.Services;
using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BookShop.WebAPI.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        public enum Additional
        {
            None = 0,
            Nowosci,
            Zapowiedzi,
            SuperOkazje
        }

        BookShopContext db = new BookShopContext();
        private readonly IBookService bookSevice = new BookService();

        // GET api/values
        [HttpGet]
        public IEnumerable<Book> Get(int category = 0, Additional additional = 0, string filtrValue = "")
        {
            return bookSevice.createQueryPrimary(db, additional, category, filtrValue).ToList();
        }

        // GET api/values/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var books = db.Books.FirstOrDefault(b => !b.IsDeleted && b.Id == id);

            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var books = db.Books.FirstOrDefault((book => !book.IsDeleted && book.Id == id));
            if (books == null)
            {
                return NotFound();
            }

            books.IsDeleted = true;
            db.SaveChanges();

            return Ok(books);
        }

        // ETAP V
        [HttpGet]
        [Route("category={category}")]
        public IEnumerable<Book> GetByCategory(string category)
        {
            return bookSevice.createQueryCategoryOnly(db, category).ToList();
        }

        [HttpGet]
        [Route("title={title}")]
        public IEnumerable<Book> GetByTitle(string title)
        {
            return bookSevice.createQueryTitleOnly(db, title).ToList();
        }

        [HttpGet]
        [Route("publishinghouse={publishingHouse}")]
        public IEnumerable<Book> GetByPublishingHouse(string publishingHouse)
        {
            return bookSevice.createQueryPublishingHouseOnly(db, publishingHouse).ToList();
        }
    }
}
