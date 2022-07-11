using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagment.Application.Interfaces.Repositories;
using OrderManagment.Application.Interfaces.Services;
using OrderManagment.Application.Services;
using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Services.Tests
{
    // since services contian single line of code
    // you might not see multiple unit test cases
    [TestClass()]
    public class ProductServiceTests
    {
        private Mock<IProductRepository> _mockProductRepository;
        private ProductService _productService;

        [TestInitialize()]
        public void ProductServiceInitalize()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);
        }

        [TestMethod()]
        public void CreateOrUpdateAsyncTest()
        {
            // arrange
            var product = new Product
            {
                ProductId = 1,
                ProductName = "lemon",
                ProductDiscription = "lemon is a citrus fruit",
                Price = 3,
                Quantity = 10
            };

            _mockProductRepository.Setup(service => service.AddOrUpdateAsync(product))
                .ReturnsAsync(true);

            // act
            var actual = _productService.CreateOrUpdateAsync(product)
                .GetAwaiter().GetResult();
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GetProductsAsyncTest()
        {
            // arrange
            var searchCriteria = new SearchCriteria();
            var expected = new List<Product>();
            expected.Add(new Product
            {
                ProductId = 1,
                ProductName = "lemon",
                ProductDiscription = "lemon is a citrus fruit",
                Price = 3,
                Quantity = 10
            });

            _mockProductRepository.Setup(service => service.GetProductsAsync(searchCriteria))
                .ReturnsAsync(expected);

            // act
            var actual = _productService.GetProductsAsync(searchCriteria)
                .GetAwaiter().GetResult();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveAsyncTest()
        {
            // arrange
            int[] productIds = new int[] { 1, 2, 3 };

            _mockProductRepository.Setup(service => service.DeleteAsync(productIds))
               .ReturnsAsync(true);

            // act
            var actual = _productService.RemoveAsync(productIds)
                .GetAwaiter().GetResult();
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void SearchByProductNameAsyncTest()
        {
            // arrange
            var productName = "lemon";
            var expected = new List<Product>();
            expected.Add(new Product
            {
                ProductId = 1,
                ProductName = "lemon",
                ProductDiscription = "lemon is a citrus fruit",
                Price = 3,
                Quantity = 10
            });

            _mockProductRepository.Setup(service => service.SearchByProductNameAsync(productName))
                .ReturnsAsync(expected);

            // act
            var actual = _productService.SearchByProductNameAsync(productName)
                .GetAwaiter().GetResult();
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}