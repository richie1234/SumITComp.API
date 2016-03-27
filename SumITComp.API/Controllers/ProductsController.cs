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
    public class ProductsController : BaseApiController
    {

        private SumITCompAPIContext db = new SumITCompAPIContext();

        public ProductsController(IRepository repo) :base(repo)
        {
        }


        // GET: api/Products
        public IEnumerable<ProductModel> GetProducts()
        {
            var results = TheRepository.GetAllProducts()
                .OrderBy(f => f.ProductId)
                .Take(25)
                .ToList()
                .Select(f => TheModelFactory.Create(f));


            return results;
        }


        // GET: api/Products/5
        public ProductModel GetProduct(int id)
        {
            //var result = _repo.GetProduct(id);

            var result = TheModelFactory.Create(TheRepository.GetProduct(id));
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
                var product = TheRepository.GetProduct(id);
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
            
               bool updateProduct= TheRepository.UpdateProduct(product);
                   
                    

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
            try
            {
                var entity = TheModelFactory.Parse(model);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not create Product Entry in the body");
                }
                // var product = TheRepository.GetProduct(productId);
                //if (product == null) Request.CreateResponse(HttpStatusCode.NotFound);
                //var diary = TheRepository.GetDiary(_identityService.CurrentUser, diaryId);
                TheRepository.InsertProduct(entity);
                if (TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(entity));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,"Could not save to the database");
                }
            }
            catch (Exception ex)
            {
                
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }


        // DELETE: api/Products/5
        public HttpResponseMessage DeleteProduct(int id)
        {

            try
            {
                if (TheRepository.GetProduct(id) == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                if (TheRepository.DeleteProductEntry(id) && TheRepository.SaveAll())
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