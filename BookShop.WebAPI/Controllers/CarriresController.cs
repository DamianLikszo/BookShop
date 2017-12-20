using BookShop.WebAPI.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace BookShop.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [System.Web.Mvc.RoutePrefix("api/carriers")]
    public class CarriresController : ApiController
    {
        private readonly BookShopContext _db;

        public CarriresController(BookShopContext db)
        {
            _db = db;
        }

        // GET api/values
        [System.Web.Http.HttpGet]
        [OutputCache(Duration = 30, VaryByParam = "none")]
        public IEnumerable<string> Get()
        {
            var carriers = _db.Carriers.Where(c => !c.IsDeleted).Select(c => c.Name);
            return carriers;
        }
    }
}
