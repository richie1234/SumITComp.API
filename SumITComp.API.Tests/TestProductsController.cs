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
        IRepository testProducts;

        [TestInitialize()]
        public void Initialize()
        {
            testProducts = new RepositoryMockTestManager();
        }

        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            // var testProducts = GetTestProducts();
           // IRepository testProducts = new RepositoryMockTestManager();

            
            var controller = new ProductsController(testProducts);

            var result = controller.GetProducts() as List<Product>;


            Assert.AreEqual(result.Count, result.Count.ToString());
        }

        [TestMethod]
        public void Product_ShouldReturnEnteredProduct()
        {
            var controller = new ProductsController(testProducts);


        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var controller = new ProductsController(testProducts);


        }

        [TestMethod]
        public void PostProduc_ShouldAddANewProduct()
        {
            var controller = new ProductsController(testProducts);

        }

        [TestMethod]
        public void PtchProduct_ShouldUpdateTheExistingProduct()
        {
            var controller = new ProductsController(testProducts);
        }

        private IQueryable<Product> GetTestProducts()
        {
            IRepository repository = new RepositoryMockTestManager();

            return repository.GetAllProducts();
        }
    }
}