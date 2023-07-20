namespace OrderManagement.Model.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
