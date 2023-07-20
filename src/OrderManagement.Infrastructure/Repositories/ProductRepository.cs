using OrderManagement.Model.Entities;
using OrderManagement.Model.Interfaces;
using OrderManagement.Model.Interfaces.Repositories;

namespace OrderManagement.Infrastructure.Repositories
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
