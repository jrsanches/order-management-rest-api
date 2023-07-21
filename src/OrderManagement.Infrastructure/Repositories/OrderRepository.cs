using Microsoft.EntityFrameworkCore;
using OrderManagement.Model.Entities;
using OrderManagement.Model.Interfaces.Repositories;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderRepository : Repository, IOrderRepository
    {

        public OrderRepository(OrderManagementContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await Task.FromResult(Context.Orders.AsEnumerable());
        }

        public async Task<IEnumerable<Order>> GetAll(Func<Order, bool> expression)
        {
            return await Task.FromResult(Context.Orders.Where(expression));
        }

        public async Task<Order> GetById(int id)
        {
            return await Task.FromResult(Context.Orders.SingleOrDefault(e => e.Id == id));
        }

        public async Task Insert(Order obj)
        {
            await Context.Database.ExecuteSqlAsync(
                $"sp_CreateOrder @CustomerId={obj.CustomerId}, @ProductId={obj.ProductId}, @QuantityOfProducts={obj.QuantityOfProducts}");
        }
    }
}
