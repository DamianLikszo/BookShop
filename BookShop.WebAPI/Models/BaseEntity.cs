using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.WebAPI.Models
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}