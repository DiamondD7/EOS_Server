namespace UserAPI.Domain.Models
{
    public class DailyEntryDTO
    {
        public int UserId { get; set; }
        public int EnergyLevel { get; set; } //range 1-10. 10 being the most energetic.
        public int SleepHours { get; set; }
        public string? JournalText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
