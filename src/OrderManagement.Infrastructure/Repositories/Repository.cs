using OrderManagement.Model.Interfaces;

namespace OrderManagement.Infrastructure.Repositories
{
    public class Repository
    {
        protected readonly IUnitOfWork UnitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
