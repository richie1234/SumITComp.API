using System;
using System.Net.Http;
using System.Web.Http.Routing;
using SumITComp.Repository.Entities;

namespace SumITComp.API.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        private IRepository _repo;

        public ModelFactory(HttpRequestMessage request, IRepository repository)
        {
            _urlHelper = new UrlHelper(request);
            _repo = repository;
        }

        public ProductModel Create(Product product)
        {
            if (product == null)
            {
                return null;
            }

            return new ProductModel()
            {

                Url = _urlHelper.Link("Product", new {productid = product.ProductId}),
                Id = product.ProductId,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price


            };
        }



        public ProductEntryModel Create(ProductEntry entry)
        {
         return new ProductEntryModel()
            {

                //Url = _urlHelper.Link("Product", new { productid = entry.ProductId }),
                Id = entry.ProductId,
                Title = entry.Title,
                Description = entry.Description,
                Price = entry.Price


            };
        }


        public ProductEntry Parse(ProductEntryModel model)
        {
            try
            {
                var entry = new ProductEntry();
                if (model.Title != default(string))
                {
                    entry.Title = model.Title;
                }
                entry.Description = model.Description;
                entry.Price = model.Price;
                return entry;
            }
            catch (Exception)
            {
                
                return null;
            }
        }
    }


}


