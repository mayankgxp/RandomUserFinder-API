using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandomUserFinder.ClientModels;
using RandomUserFinder.Services;

namespace RandomUserFinder.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IRandomUserService _randomUserService;
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;

    public UserController(IRandomUserService randomUserService, ILogger<UserController> logger, IMapper mapper)
    {
        _randomUserService = randomUserService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetRandomUser()
    {
        try
        {
            var randomUser = await _randomUserService.GetRandomUserAsync();

            if (randomUser == null)
                return Ok("No Random user has been returned."); ;

            var randomUserDto = _mapper.Map<RandomUserDto>(randomUser);

            return Ok(randomUserDto);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting the Random user details. UserController -> GetRandomUser()", ex);

            return BadRequest("Error while getting the Random user details.");
        }
    }
}
