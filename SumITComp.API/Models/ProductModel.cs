using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SumITComp.API.Models
{
    public class ProductModel
    {
        public decimal Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}