using System.Collections.Generic;
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