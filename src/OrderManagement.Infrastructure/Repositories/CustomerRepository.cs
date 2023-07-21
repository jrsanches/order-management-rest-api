using OrderManagement.Model.Entities;
using OrderManagement.Model.Interfaces.Repositories;

namespace OrderManagement.Infrastructure.Repositories
{
    public class CustomerRepository : Repository, ICustomerRepository
    {
        public CustomerRepository(OrderManagementContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await Task.FromResult(Context.Customers.AsEnumerable());
        }

        public async Task<IEnumerable<Customer>> GetAll(Func<Customer, bool> expression)
        {
            return await Task.FromResult(Context.Customers.Where(expression));
        }

        public async Task<Customer> GetById(int id)
        {
            return await Task.FromResult(Context.Customers.SingleOrDefault(e => e.Id == id));
        }

        public async Task Insert(Customer obj)
        {
            await Task.FromResult(Context.Customers.Add(obj));
        }
    }
}
