using UserAPI.Domain.Models;

namespace UserAPI.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);
        Task<bool> LoggedData(DailyEntry dailyEntry);
    }
}
