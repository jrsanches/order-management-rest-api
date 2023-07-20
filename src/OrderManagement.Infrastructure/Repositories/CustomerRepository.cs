using OrderManagement.Model.Entities;
using OrderManagement.Model.Interfaces;
using OrderManagement.Model.Interfaces.Repositories;

namespace OrderManagement.Infrastructure.Repositories
{
    public class CustomerRepository : Repository, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer obj)
        {
            throw new NotImplementedException();
        }

    }
}
