using CosmicApp.Application.User;

namespace CosmicApp.Application.Interfaces
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}