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

        //private SumITCompAPIContext db = new SumITCompAPIContext();


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

            //return new { Id = result.ProductId, Title = result.Title, Description = result.Description, Price = result.Price };


            return result;
        }

        //// PUT: api/Products/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutProduct(int id, Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.ProductId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Products
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult PostProduct(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        //}

        //// DELETE: api/Products/5
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult DeleteProduct(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Products.Remove(product);
        //    db.SaveChanges();

        //    return Ok(product);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductExists(int id)
        //{
        //    return db.Products.Count(e => e.ProductId == id) > 0;
        //}
    }
}