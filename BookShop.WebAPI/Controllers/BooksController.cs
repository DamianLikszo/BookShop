using BookShop.WebAPI.BLL.Services;
using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Models;
using System;
using System.Collections.Generic;
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
        public IEnumerable<BookDTO> Get(int category = 0, Additional additional = 0 , string filtrValue = "")
        {
            var books = bookSevice.createQuery(db, additional, category, filtrValue).ToList();
            IEnumerable<BookDTO> booksDTO = bookSevice.mapBooks(books);
            
            return booksDTO;
        }

        // GET api/values/5
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var author = db.Authors.FirstOrDefault(book => book.Id == id && !book.IsDeleted);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var author = db.Authors.FirstOrDefault(book => book.Id == id && !book.IsDeleted);
            if (author == null)
            {
                return NotFound();
            }

            author.IsDeleted = true;
            db.SaveChanges();

            return Ok();
        }

        // ETAP V
        [HttpGet]
        [Route("{category}")]
        public IEnumerable<BookDTO> GetByCategory(string category)
        {
            return null;
        }

        [HttpGet]
        [Route("{title}")]
        public IEnumerable<BookDTO> GetByTileOnly(string title)
        {
            return null;
        }

        [HttpGet]
        [Route("{publishingHouse}")]
        public IEnumerable<BookDTO> getbypublishinghouse(string publishingHouse)
        {
            return null;
        }
    }
}
