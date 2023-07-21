using System.Security.Claims;

namespace OrderManagement.Api.Providers
{
    public class ContextUserDataProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextUserDataProvider()
        {

        }

        public ContextUserDataProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual int GetCustomerId()
        {
            return Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}
