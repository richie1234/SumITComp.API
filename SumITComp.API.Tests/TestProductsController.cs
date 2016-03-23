using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumITComp.API.Controllers;
using SumITComp.API.Models;
using SumITComp.Repository.Entities;

namespace SumITComp.API.Tests
{
    /// <summary>
    /// Summary description for TestProductsController
    /// </summary>
    [TestClass]
    public class TestProductsController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
           // var testProducts = GetTestProducts();
            IRepository testProducts = new RepositoryMockTestManager();
            var controller = new ProductsController(testProducts);

            var result = controller.GetProducts() as List<Product>;


            Assert.AreEqual(result.Count, result.Count.ToString());
        }

        //[TestMethod]
        //public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        //{
        //    var testProducts = GetTestProducts();
        //    var controller = new ProductsController(testProducts);

        //    var result = await controller.GetAllProductsAsync() as List<Product>;
        //    Assert.AreEqual(testProducts.Count, result.Count);
        //}

        //[TestMethod]
        //public void GetProduct_ShouldReturnCorrectProduct()
        //{
        //    var testProducts = GetTestProducts();
        //    var controller = new ProductsController(testProducts);

        //    var result = controller.GetProduct(4) as OkNegotiatedContentResult<Product>;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        //}

        //[TestMethod]
        //public async Task GetProductAsync_ShouldReturnCorrectProduct()
        //{
        //    var testProducts = GetTestProducts();
        //    var controller = new ProductsController(testProducts);

        //    var result = await controller.GetProductAsync(4) as OkNegotiatedContentResult<Product>;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(testProducts[3].Name, result.Content.Name);
        //}

        //[TestMethod]
        //public void GetProduct_ShouldNotFindProduct()
        //{
        //    var controller = new ProductsController(GetTestProducts());

        //    var result = controller.GetProduct(999);
        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}

        //private IQueryable<Product> GetTestProducts()
        //{
        //    IRepository repository = new RepositoryMockTestManager();

        //    return repository.GetAllProducts();
        //}
    }
}