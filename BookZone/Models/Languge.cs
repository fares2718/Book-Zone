namespace BookZone.Models
{
    public class Languge : BaseEntity
    {
        public string Icon { get; set; } = string.Empty;
        public ICollection<BookLanguge> books { get; set; } = new List<BookLanguge>();
    }
}
