using Microsoft.AspNetCore.Mvc;
using RandomUserFinder.Models;
using RandomUserFinder.Services;

namespace RandomUserFinder.Controllers;


[Route("api/[controller]")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public ActionResult<bool> Post([FromBody] Credential creds)
    {
        return _authService.ValidateCredentials(creds.UserName, creds.Password);
    }
}
