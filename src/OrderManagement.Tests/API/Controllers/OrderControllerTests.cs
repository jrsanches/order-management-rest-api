using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderManagement.Api.Controllers;
using OrderManagement.Api.Models.Requests;
using OrderManagement.Api.Providers;
using OrderManagement.Infrastructure.Interfaces;
using OrderManagement.Model.Entities;
using OrderManagement.Model.Interfaces.Repositories;
using Xunit;

namespace OrderManagement.Tests.API.Controllers
{
    public class OrderControllerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<ContextUserDataProvider> _contextUserDataProvider;
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly OrderController _sut;

        public OrderControllerTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _contextUserDataProvider = new Mock<ContextUserDataProvider>();
            _productRepository = new Mock<IProductRepository>();
            _orderRepository = new Mock<IOrderRepository>();

            _unitOfWork.Setup(e => e.ProductRepository).Returns(_productRepository.Object);
            _unitOfWork.Setup(e => e.OrderRepository).Returns(_orderRepository.Object);

            _sut = new OrderController(_unitOfWork.Object, _contextUserDataProvider.Object);
        }

        [Fact]
        public async Task Should_PostOrder_Return_CreatedStatus()
        {
            //arrange
            var model = new OrderModel()
            {
                ProductId = 1,
                QuantityOfProducts = 2
            };

            var product = new Product()
            {
                Id = 1,
                Name = "Test",
                Price = 200m
            };

            var customerId = 3;

            _productRepository.Setup(e => e.GetById(model.ProductId))
                .ReturnsAsync(product);

            _contextUserDataProvider.Setup(e => e.GetCustomerId())
                .Returns(customerId);

            //act
            var result = await _sut.PostOrder(model);
            var statusCodeResult = result as StatusCodeResult;

            //assert
            statusCodeResult?.StatusCode.Should().Be(StatusCodes.Status201Created);

            _orderRepository.Verify(e => e.Insert(It.IsAny<Order>()), Times.Once);
            _unitOfWork.Verify(e => e.Commit(), Times.Once);
        }

        [Fact]
        public async Task Should_PostOrder_Return_NotFoundStatus_When_Product_NotExists()
        {
            //arrange
            var model = new OrderModel()
            {
                ProductId = 1,
                QuantityOfProducts = 2
            };

            //act
            var result = await _sut.PostOrder(model);
            var notFoundResult = result as NotFoundObjectResult;

            //assert
            notFoundResult?.Value.Should().Be($"Product {model.ProductId} not found.");

            _orderRepository.Verify(e => e.Insert(It.IsAny<Order>()), Times.Never);
            _unitOfWork.Verify(e => e.Commit(), Times.Never);
        }
    }
}
