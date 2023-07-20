using OrderManagement.Model.Interfaces;

namespace OrderManagement.Infrastructure
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly OrderManagementContext _context;

        public UnitOfWork(OrderManagementContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
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

