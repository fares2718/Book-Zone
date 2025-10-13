namespace BookZone.Models
{
    public class Author : BaseEntity
    {
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
