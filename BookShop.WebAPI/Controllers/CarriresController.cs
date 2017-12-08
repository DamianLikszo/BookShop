using BookShop.WebAPI.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace BookShop.WebAPI.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/carriers")]
    public class CarriresController : ApiController
    {
        BookShopContext db = new BookShopContext();

        // GET api/values
        [System.Web.Http.HttpGet]
        [OutputCache(Duration = 900, VaryByParam = "none")]
        public IEnumerable<string> Get()
        {
            return db.Carriers.Where(c => !c.IsDeleted).Select(c => c.Name);
        }
    }
}
