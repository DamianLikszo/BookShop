using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateRelease { get; set; }
        public bool Opportunity { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int CarrierId { get; set; }
        public virtual Carrier Carrier { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int PublishingHouseId { get; set; }
        public virtual PublishingHouse PublishingHouse { get; set; }
    }
}