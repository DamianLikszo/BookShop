using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}