using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.Models
{
    public class PublishingHouse
    {
        public uint PublishingHouseId { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}