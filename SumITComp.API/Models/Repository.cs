using System.Linq;
using SumITComp.Repository.Entities;

namespace SumITComp.API.Models
{
    public class Repository : IRepository
    {
        private SumITCompAPIContext _ctx;

        public Repository(SumITCompAPIContext ctx)
        {
            this._ctx = ctx;
        }


        public IQueryable<Product> GetAllProducts()
        {
            return _ctx.Products;
        }

        public Product GetProduct(int id)
        {
            return _ctx.Products.Where(f => f.ProductId == id).FirstOrDefault(); ;
        }

        public bool InsertProduct(ProductEntry entry)
        {
            try
            {
                Product product = new Product();
                product.Title = entry.Title;
                product.Description = entry.Description;
                product.Price = entry.Price;
                _ctx.Products.Add(product);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public bool DeleteProductEntry(int id)
        {
            try
            {
                var entity = _ctx.Products.Where(f => f.ProductId == id).FirstOrDefault();
                if (entity != null)
                {
                    _ctx.Products.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // TODO Logging
            }

            return false;
        }

        public bool UpdateProduct(Product product)
        {
            if (product != null)
            {
                _ctx.Products.Attach(product);
                // _ctx.Products.Attach(new Product() {ProductId = 1,Title = "hello",Description = "Rambo",Price = 70});

                _ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
