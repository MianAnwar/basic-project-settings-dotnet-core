using Application.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public string UserId { get; }

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
