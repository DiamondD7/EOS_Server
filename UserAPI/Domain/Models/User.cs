using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAPI.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public ICollection<DailyEntry>? DailyEntry { get; set; } = new List<DailyEntry>();
    }

    public class DailyEntry
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int EnergyLevel { get; set; } //range 1-10. 10 being the most energetic.
        public int OutputWork { get; set; }
        public int MoodLevel { get; set; }
        public double SleepHours { get; set; }
        public string? JournalText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
