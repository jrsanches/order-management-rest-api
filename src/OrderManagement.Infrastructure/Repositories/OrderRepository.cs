using OrderManagement.Model.Entities;
using OrderManagement.Model.Interfaces;
using OrderManagement.Model.Interfaces.Repositories;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
