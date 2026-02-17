using UserAPI.Domain.Models;

namespace UserAPI.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<int>CheckUserIdentityAsync(User user);
        Task<bool> CreateUserAsync(User user);
        Task<bool> LoggedDataAsync(DailyEntryDTO dailyEntryModel);
    }
}
