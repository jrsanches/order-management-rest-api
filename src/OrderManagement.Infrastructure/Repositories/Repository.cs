namespace OrderManagement.Infrastructure.Repositories
{
    public class Repository
    {
        protected readonly OrderManagementContext Context;

        public Repository(OrderManagementContext context)
        {
            Context = context;
        }
    }
}
