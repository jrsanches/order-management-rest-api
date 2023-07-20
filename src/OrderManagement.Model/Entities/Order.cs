using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Model.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int QuantityOfProducts { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal TotalCost { get; set; }
    }
}
