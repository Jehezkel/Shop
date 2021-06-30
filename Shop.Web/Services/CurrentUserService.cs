using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Shop.Web.Services
{
    public class CurrentUserService
    {
        private readonly IHttpContextAccessor _httpConextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpConextAccessor = httpContextAccessor;
        }
        public string Userid => _httpConextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}