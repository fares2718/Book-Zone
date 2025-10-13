namespace BookZone.Models
{
    public class BookLanguge
    {
        public int BookId { get; set; }
        public Book Book { get; set; } = default!;
        public int LangugeId { get; set; }
        public Languge Languge { get; set; } = default!;
    }
}
