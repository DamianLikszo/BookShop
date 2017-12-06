using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.Models
{
    public class Book
    {
        public uint BookId { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateRelease { get; set; }
        public bool Opportunity { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }

        public uint AuhtorId { get; set; }
        public virtual Author Author { get; set; }

        public uint CarrierId { get; set; }
        public virtual Carrier Carrier { get; set; }

        public uint CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public uint PublishingHouseId { get; set; }
        public virtual PublishingHouse PublishingHouse { get; set; }
    }
}