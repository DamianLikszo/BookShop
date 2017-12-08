using BookShop.WebAPI.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace BookShop.WebAPI.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private readonly BookShopContext _db = new BookShopContext();

        // GET api/values
        [System.Web.Http.HttpGet]
        [OutputCache(Duration = 30, VaryByParam = "none")]
        public IEnumerable<string> Get()
        {
            var categories = _db.Caregories.Where(c => !c.IsDeleted).Select(c => c.Name);
            return categories;
        }
    }
}
