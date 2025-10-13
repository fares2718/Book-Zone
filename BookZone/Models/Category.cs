namespace BookZone.Models
{
    public class Category : BaseEntity
    {
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
