using OrderManagement.Infrastructure.Interfaces;
using OrderManagement.Infrastructure.Repositories;
using OrderManagement.Model.Interfaces.Repositories;

namespace OrderManagement.Infrastructure
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly OrderManagementContext _context;

        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;

        public UnitOfWork(OrderManagementContext context)
        {
            _context = context;
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_context);
                }

                return _customerRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_context);
                }

                return _orderRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }

                return _productRepository;
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}

