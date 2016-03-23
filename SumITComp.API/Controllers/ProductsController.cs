using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SumITComp.API.Models;
using SumITComp.Repository.Entities;


namespace SumITComp.API.Controllers
{
    public class ProductsController : ApiController
    {
        private IRepository _repo;
        private ModelFactory _modelFactory;

        public ProductsController(IRepository repo)
        {
            _repo = repo;
            _modelFactory = new ModelFactory();
        }


        // GET: api/Products
        public IEnumerable<ProductModel> GetProducts()
        {
            var results = _repo.GetAllProducts()
                .OrderBy(f => f.ProductId)
                .Take(25)
                .ToList()
                .Select(f => _modelFactory.Create(f));


            return results;
        }


        // GET: api/Products/5
        public ProductModel GetProduct(int id)
        {
            //var result = _repo.GetProduct(id);

            var result = _modelFactory.Create(_repo.GetProduct(id));
            if (result == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID = {0}", id)),
                    ReasonPhrase = "Product ID Not Found"
                };

                throw new HttpResponseException(resp);
            }

            return result;
        }


        [HttpPut]
        [HttpPatch]
        public HttpResponseMessage PutProduct(int id, [FromBody] ProductEntryModel productEntryentry)
        {

            try
            {
                var product = _repo.GetProduct(id);
                if (product == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                //var updatedProduct = new Product() {Title = model.Title, Description = model.Description, Price=model.Price,ProductId=id};


                if (product.Title != productEntryentry.Title)
                {
                    product.Title = productEntryentry.Title;

                }
                if (product.Description != productEntryentry.Description)
                {
                    product.Description = productEntryentry.Description;

                }
                if (product.Price != productEntryentry.Price)
                {
                    product.Price = productEntryentry.Price;

                }
            
               bool updateProduct=  _repo.UpdateProduct(product);
                   
                    

                if (updateProduct)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    

    // POST: api/Products
        public HttpResponseMessage PostProduct([FromBody]ProductEntryModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            _repo.AddProduct(new Product() { Title = model.Title,Description = model.Description,Price = model.Price});
            _repo.SaveAll();

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        // DELETE: api/Products/5
        public HttpResponseMessage DeleteProduct(int id)
        {

            try
            {
                if (_repo.GetProduct(id) == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                if (_repo.DeleteProductEntry(id) && _repo.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }
        

    }
}