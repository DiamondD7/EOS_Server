namespace UserAPI.Domain.Models
{
    public class DailyEntryDTO
    {
        public int UserId { get; set; }
        public int EnergyLevel { get; set; } //range 1-10. 10 being the most energetic.
        public int OutputWork { get; set; }
        public int MoodLevel { get; set; }
        public double SleepHours { get; set; }
        public string? JournalText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
