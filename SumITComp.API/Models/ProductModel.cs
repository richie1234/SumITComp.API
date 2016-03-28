using System;

namespace SumITComp.API.Models
{
    public class ProductModel
    {
        private decimal _price;
        public string Url { get; set; }
        public decimal Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price {
            get { return Math.Round(_price, 4); } 
            set { _price = value; } 
        }

        public decimal GST => Math.Round(this.Price/11m, 4);
    }
}