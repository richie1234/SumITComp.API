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
using System.Web.Http.Routing;
using SumITComp.API.Models;
using SumITComp.Repository.Entities;


namespace SumITComp.API.Controllers
{
    public class ProductsController : BaseApiController
    {

       

        public ProductsController(IRepository repo) :base(repo)
        {
        }

        const int PAGE_SIZE = 5;

        // GET: api/Products
        public object GetProducts(int page = 0)
        {
            var baseQuery = TheRepository.GetAllProducts()
                .OrderBy(f => f.ProductId);

            var totalCount = baseQuery.Count();
            var totalPages = Math.Ceiling((double) totalCount/PAGE_SIZE);

            var helper = new UrlHelper(Request) ;
            var prevUrl = page > 0 ? helper.Link("product", new {page = page-1}) : "";
            var nextUrl = page < totalPages -1 ? helper.Link("product", new { page = page + 1 }) : "";



            var results = baseQuery.Skip(PAGE_SIZE * page)
                .Take(PAGE_SIZE)
                .ToList()
                .Select(f => TheModelFactory.Create(f));

            return new
            {
                TotalCount =totalCount,
                TotalPages = totalPages,
                PrevPageUrl = prevUrl,
                NextPageUrl = nextUrl,
                Results = results
            };
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
        public HttpResponseMessage PutProduct(int id, [FromBody]ProductEntryModel model)
        {


            try
            {
                var entity = TheRepository.GetProduct(id); ;
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not find the Product Id");
                }

                var passedValue = TheModelFactory.Parse(model);
                if (passedValue == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read diary entry in body");
                }

                if (entity.Title != passedValue.Title || entity.Description != passedValue.Description ||
                    entity.Price != passedValue.Price)
                {
                    if (passedValue.Title != null)
                    {
                        entity.Title = passedValue.Title;
                    }
                    if (passedValue.Description != null)
                    {
                        entity.Description = passedValue.Description;
                    }
                    if (passedValue.Price != null)
                    {
                        entity.Price = (decimal) passedValue.Price;
                    }

                    
                    if (TheRepository.SaveAll())
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(entity));
                    }


                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);


            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            //try
            //{
            //    var product = TheRepository.GetProduct(id);
            //    if (product == null)
            //        return Request.CreateResponse(HttpStatusCode.BadRequest);

            //    //var updatedProduct = new Product() {Title = model.Title, Description = model.Description, Price=model.Price,ProductId=id};


            //    if (product.Title != productEntryentry.Title)
            //    {
            //        product.Title = productEntryentry.Title;

            //    }
            //    if (product.Description != productEntryentry.Description)
            //    {
            //        product.Description = productEntryentry.Description;

            //    }
            //    if (product.Price != productEntryentry.Price)
            //    {
            //        product.Price = productEntryentry.Price;

            //    }

            //   bool updateProduct= TheRepository.UpdateProduct(product);



            //    if (updateProduct)
            //    {
            //        return Request.CreateResponse(HttpStatusCode.OK);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}

            //return Request.CreateResponse(HttpStatusCode.BadRequest);
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