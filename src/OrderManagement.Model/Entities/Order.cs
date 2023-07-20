namespace OrderManagement.Model.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int QuantityOfProducts { get; set; }
        public decimal TotalCost { get; set; }
    }
}
