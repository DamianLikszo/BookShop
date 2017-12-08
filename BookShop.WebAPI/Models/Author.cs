using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookShop.WebAPI.Models
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}