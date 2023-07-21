using OrderManagement.Model.Interfaces.Repositories;

namespace OrderManagement.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }

        Task Commit();
    }
}