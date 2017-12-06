﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.Models
{
    public class Author
    {
        public uint AuthorId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}