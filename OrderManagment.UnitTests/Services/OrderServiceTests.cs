using Moq;
using OrderManagment.Application.Interfaces.Repositories;
using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;

namespace OrderManagment.Application.Services.Tests
{
    // since services contian single line of code
    // you might not see multiple unit test cases
    [TestClass()]
    public class OrderServiceTests
    {
        private Mock<IOrderRepository> _mockOrderRepository;
        private OrderService _orderService;

        [TestInitialize()]
        public void OrderServiceTest()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _orderService = new OrderService(_mockOrderRepository.Object);
        }

        [TestMethod()]
        public void CreateOrUpdateItemAsyncTest()
        {
            // arrange
            var orderItem = new OrderItem
            {
                ProductId = 1,
                OrderId = 1,
                Price = 3,
                Quantity = 10
            };

            _mockOrderRepository.Setup(service => service.AddOrUpdateItemAsync(orderItem))
                .ReturnsAsync(true);

            // act
            var actual = _orderService.CreateOrUpdateItemAsync(orderItem)
                .GetAwaiter().GetResult();
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GetOrdersAsyncTest()
        {
            // arrange
            var searchCriteria = new SearchCriteria();
            var expected = new List<Order>();
            expected.Add(new Order
            {
                OrderId = 1,
                OrderNumber = "ORD100",
                OrderDate = DateTime.Now,
                CustomerId = 1,
            });

            _mockOrderRepository.Setup(service => service.GetOrdersAsync(searchCriteria))
                .ReturnsAsync(expected);

            // act
            var actual = _orderService.GetOrdersAsync(searchCriteria)
                .GetAwaiter().GetResult();
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveItemAsyncTest()
        {
            // arrange
            int[] itemIds = new int[] { 1, 2, 3 };

            _mockOrderRepository.Setup(service => service.DeleteItemsAsync(itemIds))
               .ReturnsAsync(true);

            // act
            var actual = _orderService.RemoveItemAsync(itemIds)
                .GetAwaiter().GetResult();
            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void SearchByOrderNumberAsyncTest()
        {
            // arrange
            var orderNumber = "ORD100";
            var expected = new List<Order>();
            expected.Add(new Order
            {
                OrderId = 1,
                OrderNumber = orderNumber,
                OrderDate = DateTime.Now,
                CustomerId = 1,
            });

            _mockOrderRepository.Setup(service => service.SearchByOrderNumberAsync(orderNumber))
                .ReturnsAsync(expected);

            // act
            var actual = _orderService.SearchByOrderNumberAsync(orderNumber)
                .GetAwaiter().GetResult();
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}