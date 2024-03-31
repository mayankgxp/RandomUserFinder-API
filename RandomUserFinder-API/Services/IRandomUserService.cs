using RandomUserFinder.Models;

namespace RandomUserFinder.Services
{
    public interface IRandomUserService
    {
        Task<RandomUser?> GetRandomUserAsync();
    }
}
