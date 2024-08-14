namespace CosmicApp.Application.User
{
    public interface IUserContext
    {
        CurrentUser GetCurrentUser();
    }
}