using OrderManagement.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Api.Models.Requests
{
    public class OrderModel
    {
        [Required]
        public int ProductId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int QuantityOfProducts { get; set; }

        public Order BuildOrder(int customerId, Product product)
        {
            return new Order()
            {
                CustomerId = customerId,
                ProductId = ProductId,
                QuantityOfProducts = QuantityOfProducts
            };
        }
    }
}
