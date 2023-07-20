using Microsoft.EntityFrameworkCore;
using OrderManagement.Model.Entities;

namespace OrderManagement.Infrastructure
{
    public class OrderManagementContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Product> Products => Set<Product>();

        public OrderManagementContext(DbContextOptions<OrderManagementContext> options) : base(options)
        {

        }
    }
}