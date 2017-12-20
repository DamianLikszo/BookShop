using BookShop.WebAPI.BLL.Services;
using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using BookShop.WebAPI.Enums;

namespace BookShop.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly BookShopContext _db;
        private readonly IBookService _bookSevice;

        public BooksController(BookShopContext db, IBookService bookSevice)
        {
            _db = db;
            _bookSevice = bookSevice;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Book> Get(int category = 0, ExtraCategory extraCategory = 0, string filtrValue = "")
        {
            var books = _bookSevice.createQuery(extraCategory, category, filtrValue);
            return books;
        }

        // GET api/values/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var books = _db.Books.FirstOrDefault(b => !b.IsDeleted && b.Id == id);

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
            var books = _db.Books.FirstOrDefault((book => !book.IsDeleted && book.Id == id));
            if (books == null)
            {
                return NotFound();
            }

            books.IsDeleted = true;
            _db.SaveChanges();

            return Ok(books);
        }
    }
}
