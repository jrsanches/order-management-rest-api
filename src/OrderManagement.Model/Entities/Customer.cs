using Microsoft.AspNetCore.Identity;

namespace OrderManagement.Model.Entities
{
    public class Customer : IdentityUser<int>
    {
        public string? Password { get; set; }
    }
}
