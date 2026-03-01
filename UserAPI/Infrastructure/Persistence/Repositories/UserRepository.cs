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

        public async Task<int> CheckUserIdentityAsync(User user)
        {
            var existingUser = await _context.UserTable.FirstOrDefaultAsync(x => x.Email == user.Email);
            if(existingUser != null)
            {
                return existingUser.Id;
            }
            return 0;
        }



        public async Task<bool> CreateUserAsync(User user)
        {
            if(user == null)
            {
                return false;
            }

            _context.UserTable.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoggedDataAsync(DailyEntryDTO dailyEntryModel)
        {
            var existingUser = await _context.UserTable.Include(x => x.DailyEntry).FirstOrDefaultAsync(x => x.Id == dailyEntryModel.UserId);

            if(existingUser == null)
            {
                return false;
            }

            existingUser.DailyEntry.Add(new DailyEntry
            {
                UserId = dailyEntryModel.UserId,
                MoodLevel = dailyEntryModel.MoodLevel,
                OutputWork = dailyEntryModel.OutputWork,
                EnergyLevel = dailyEntryModel.EnergyLevel,
                SleepHours = dailyEntryModel.SleepHours,
                JournalText = dailyEntryModel.JournalText,
                CreatedAt = DateTime.UtcNow
            });



            await _context.SaveChangesAsync();
            return true;
        }


    }
}
