using System.Text;

namespace RandomUserFinder.Services;

public class AuthService: IAuthService
{
    private readonly IConfiguration _config;

    public AuthService(IConfiguration config) {
        _config = config;
    }

    public bool IsAuthorized(string userName, string password)
    {
        if (ValidateCredentials(userName, password))
        {
            return true;
        }

        return false;

    }

    public (string userName, string password) ExtractCredentials(string authHeader)
    {
        var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

        var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

        var username = decodedUsernamePassword.Split(':', 2)[0];
        var password = decodedUsernamePassword.Split(':', 2)[1];

        return (username, password);
    }

    public bool ValidateCredentials(string username, string password)
    {
        var _userName = _config["Credentials:UserName"];
        var _password = _config["Credentials:Password"];

        return username.Equals(_userName, StringComparison.InvariantCultureIgnoreCase) && password.Equals(_password);
    }
}
