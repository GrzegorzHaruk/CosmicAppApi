using CosmicApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CosmicApp.Application.User
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("User context is not present");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var userId = user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(x => x.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(x => x.Type == ClaimTypes.Role)!.Select(x => x.Value);
            var nationality = user.FindFirst(x => x.Type == "Nationality")?.Value;
            var dateOfBirthString = user.FindFirst(x => x.Type == "DateOfBirth")?.Value;
            var dateOfBirth = dateOfBirthString == null 
                ? (DateOnly?)null 
                : DateOnly.ParseExact(dateOfBirthString, "yyyy-MM-dd");

            return new CurrentUser(userId, email, roles, dateOfBirthString, dateOfBirth);
        }
    }
}
