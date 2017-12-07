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
    public class BookController : ApiController
    {
        public enum Additional
        {
            None = 0,
            Nowosci,
            Zapowiedzi,
            SuperOkazje
        }

        BookShopContext db = new BookShopContext();

        // GET api/values
        public IEnumerable<BookDTO> Get(string filtrValue = "", bool autorInFiltr = false, int category = 0, Additional additional = 0)
        {
            filtrValue = filtrValue.ToLower();
            var query = db.Books.AsQueryable();
            query = query.Where(book => !book.IsDeleted);

            DateTime dateFrom, dateTo, dateNow = DateTime.Now;
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
                if (autorInFiltr)
                    query = query.Where(book => book.Title.ToLower().Contains(filtrValue) ||
                                                (book.Author.FirstName.ToLower()+" "+book.Author.LastName.ToLower()).Contains(filtrValue) || 
                                                (book.Author.LastName.ToLower() +" "+ book.Author.FirstName.ToLower()).Contains(filtrValue)
                                                );
                else
                    query = query.Where(book => book.Title.ToLower().Contains(filtrValue));
            }
            if (category > 0)
                query = query.Where(book => category == book.CategoryId);

            List<BookDTO> BookDTO = new List<BookDTO>();
            foreach (Book book in query.ToList())
            {
                BookDTO.Add(new BookDTO(book));
            }

            return BookDTO;
        }

        // GET api/values/5
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
    }
}
