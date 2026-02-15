using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserAPI.Application.Interfaces.Repositories;
using UserAPI.Domain.Models;

namespace UserAPI.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<bool> CreateUser(User user)
        {
            if(user == null)
            {
                return false;
            }

            _context.UserTable.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoggedData(DailyEntry dailyEntry)
        {
            var existingUser = await _context.UserTable.Include(x => x.DailyEntry).FirstOrDefaultAsync(x => x.Id == dailyEntry.UserId);

            if(existingUser == null)
            {
                return false;
            }

            existingUser.DailyEntry.Add(new DailyEntry
            {
                UserId = dailyEntry.UserId,
                EnergyLevel = dailyEntry.EnergyLevel,
                SleepHours = dailyEntry.SleepHours,
                JournalText = dailyEntry.JournalText,
                CreatedAt = DateTime.Now
            });

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
