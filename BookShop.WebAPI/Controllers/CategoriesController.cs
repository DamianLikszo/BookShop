using BookShop.WebAPI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShop.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        BookShopContext db = new BookShopContext();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return db.Caregories.Where(c => !c.IsDeleted).Select(c => c.Name);
        }
    }
}
