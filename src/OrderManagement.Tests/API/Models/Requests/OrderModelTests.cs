using FluentAssertions;
using OrderManagement.Api.Models.Requests;
using OrderManagement.Model.Entities;
using Xunit;

namespace OrderManagement.Tests.API.Models.Requests
{
    public class OrderModelTests
    {
        [Fact]
        public void Should_Build_Order_Correctly()
        {
            //arrange
            var sut = new OrderModel()
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

            //act
            var order = sut.BuildOrder(customerId, product);

            //assert
            order.CustomerId.Should().Be(customerId);
            order.ProductId.Should().Be(product.Id);
            order.QuantityOfProducts.Should().Be(sut.QuantityOfProducts);
            order.TotalCost.Should().Be(0);
        }
    }
}
