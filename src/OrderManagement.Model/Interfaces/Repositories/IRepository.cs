namespace OrderManagement.Model.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Func<T, bool> expression);
        Task<T> GetById(int id);
        Task Insert(T obj);
    }
}
