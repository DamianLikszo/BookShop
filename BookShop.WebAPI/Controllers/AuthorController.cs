using BookShop.WebAPI.DAL;
using BookShop.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShop.WebAPI.Controllers
{
    public class AuthorController : ApiController
    {
        BookShopContext db = new BookShopContext();

        // GET api/values
        public IEnumerable<Author> Get()
        {
            return db.Authors.Where(a => !a.IsDeleted).ToList();
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var author = db.Authors.FirstOrDefault((a) => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            var author = db.Authors.FirstOrDefault((a) => a.Id == id);
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
