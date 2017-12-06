using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.Models
{
    public class Carrier
    {
        public int CarrierId { get; set; }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}