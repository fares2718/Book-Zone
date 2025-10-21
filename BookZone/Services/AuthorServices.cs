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

        public async Task AddNew(string name)
        {
            await _context.Authors.AddAsync(new Author { Name = name });
            await _context.SaveChangesAsync();

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
