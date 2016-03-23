using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SumITComp.Repository.Entities;

namespace SumITComp.API.Models
{
    public class ModelFactory
    {

        public ProductModel Create(Product product)
        {
            if (product == null)
            {
                return null;
            }

            return new ProductModel()
            {

                Id = product.ProductId,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price


            };
        }
    }


}


