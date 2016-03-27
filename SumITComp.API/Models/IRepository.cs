using System.Linq;
using SumITComp.Repository.Entities;

namespace SumITComp.API.Models
{
    public interface IRepository
    {
        IQueryable<Product> GetAllProducts();
        //IQueryable<Order> GetAllOrders();
        //IQueryable<Order> GetAllOrdersWithDetails();
        //Order GetOrder(int id);
        Product GetProduct(int id);
        bool InsertProduct(ProductEntry product);
        bool SaveAll();
        bool DeleteProductEntry(int id);
        bool UpdateProduct(Product product);
    }
}