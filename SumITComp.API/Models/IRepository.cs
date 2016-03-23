using System.Linq;
using SumITComp.Repository.Entities;

namespace SumITComp.API.Models
{
    public interface IRepository
    {
        IQueryable<Product> GetAllProducts();
        IQueryable<Order> GetAllOrders();
        IQueryable<Order> GetAllOrdersWithDetails();
        Order GetOrder(int id);
    }
}