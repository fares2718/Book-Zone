using BookZone.Data;
using BookZone.Models;

namespace BookZone.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly ApplicationDbContext _context;

        public AuthorServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public Author GetAuthor(string name)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Name == name);
            if (author == null)
                return default!;
            return author;
        }
    }
}
