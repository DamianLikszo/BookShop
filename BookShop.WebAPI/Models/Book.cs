using System;

namespace BookShop.WebAPI.Models
{
    public class Book : BaseEntity
    {
        public DateTime DateAdded { get; set; }
        public DateTime DateRelease { get; set; }
        public bool Opportunity { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual PublishingHouse PublishingHouse { get; set; }
    }
}