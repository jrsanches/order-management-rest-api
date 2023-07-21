using OrderManagement.Model.Entities;
using OrderManagement.Model.Interfaces.Repositories;

namespace OrderManagement.Infrastructure.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(OrderManagementContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await Task.FromResult(Context.Products.AsEnumerable());
        }

        public async Task<IEnumerable<Product>> GetAll(Func<Product, bool> expression)
        {
            return await Task.FromResult(Context.Products.Where(expression));
        }

        public async Task<Product> GetById(int id)
        {
            return await Task.FromResult(Context.Products.SingleOrDefault(e => e.Id == id));
        }

        public async Task Insert(Product obj)
        {
            await Task.FromResult(Context.Products.Add(obj));
        }
    }
}
