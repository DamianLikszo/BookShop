using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BookShop.WebAPI.Models
{
    public class PublishingHouse : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}