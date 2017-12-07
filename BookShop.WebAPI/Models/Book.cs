using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.Models
{
    public class Book : BaseEntity
    {
        public DateTime DateAdded { get; set; }
        public DateTime DateRelease { get; set; }
        public bool Opportunity { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }

        public long AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public long CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }

        public long PublishingHouseId { get; set; }
        [JsonIgnore]
        public virtual PublishingHouse PublishingHouse { get; set; }
    }
}