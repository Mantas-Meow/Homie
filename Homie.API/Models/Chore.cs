namespace Homie.API.Models
{
    public class Chore
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Frequency Frequency { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public enum Frequency
    {
        Daily,
        Weekly,
        BiWeekly,
        Montly,
        EvenDays,
        NotEvenDays
    }
}
