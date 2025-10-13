using System.ComponentModel.DataAnnotations;

namespace BookZone.Models
{
    public class Book : BaseEntity
    {
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;
        public int AuthorId {get; set; }
        public Author Author { get; set; } = default!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public ICollection<BookLanguge> languges = new List<BookLanguge>();
    }
}
