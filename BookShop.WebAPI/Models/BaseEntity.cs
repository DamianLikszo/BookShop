using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BookShop.WebAPI.Models
{
    public class BaseEntity
    {
        public long Id { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}