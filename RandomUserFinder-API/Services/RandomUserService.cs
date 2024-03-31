using Newtonsoft.Json;
using RandomUserFinder.Models;

namespace RandomUserFinder.Services;

public class RandomUserService : IRandomUserService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _config;

    public RandomUserService(IHttpClientFactory clientFactory, IConfiguration config)
    {
        _clientFactory = clientFactory;
        _config = config;
    }

    public async Task<RandomUser?> GetRandomUserAsync()
    {
        try
        {
            using var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(_config["RandomUserAPIUrl"]);
            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadAsStringAsync();

                var randomUsers = JsonConvert.DeserializeObject<RandomUser>(users);

                return randomUsers;
            }

            return null;
        }
        catch
        {
            throw;
        }
    }
}
