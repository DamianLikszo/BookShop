using System.Collections.Generic;
using Newtonsoft.Json;

namespace BookShop.WebAPI.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}