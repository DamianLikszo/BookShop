using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.Models
{
    public class BookDTO
    {
        public DateTime DateAdded { get; set; }
        public DateTime DateRelease { get; set; }
        public bool Opportunity { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }

        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public BookDTO( Book book )
        {
            AuthorFirstName = book.Author.FirstName;
            AuthorLastName = book.Author.LastName;

            DateAdded = book.DateAdded;
            DateRelease = book.DateRelease;
            Opportunity = book.Opportunity;
            Price = book.Price;
            Title = book.Title;
        }
    }
}