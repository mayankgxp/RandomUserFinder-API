namespace RandomUserFinder.Services
{
    public interface IAuthService
    {
        bool IsAuthorized(string userName, string password);
        bool ValidateCredentials(string username, string password);
        (string userName, string password) ExtractCredentials(string authHeader);
    }
}
