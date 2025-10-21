using BookZone.Data;
using BookZone.Models;
using BookZone.Settings;
using BookZone.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookZone.Services
{
    public class BookServices : IBookServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorServices _authorServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public BookServices(ApplicationDbContext context, IAuthorServices authorServices,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _authorServices = authorServices;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }

        public async Task AddNewBook(CreatBookViewModel book)
        {
            string coverName = $"{Guid.NewGuid()}{Path.GetExtension(book.Cover.FileName)}";
            var path = Path.Combine(_imagesPath, coverName) ;
            using var stream = File.Create(path) ;
            await book.Cover.CopyToAsync(stream) ;
            if (_authorServices.GetAuthor(book.AuthorName) == null)
            {
                await _authorServices.AddNew(book.AuthorName);
            }
            int authorId = _authorServices.GetAuthor(book.AuthorName).Id;
            Book newBook = new()
            {
                Name = book.Name,
                CategoryId = book.CategoryId,
                Cover = coverName,
                Description = book.Description,
                AuthorId = authorId,
                languges = book.SelectedLanguages.Select(l => new BookLanguge { LangugeId = l }).ToList()
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.languges)
                .ThenInclude(l => l.Languge)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Book?> GetBookById(int Id)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.languges)
                .ThenInclude(l => l.Languge)
                .AsNoTracking()
                .SingleOrDefaultAsync(b => b.Id == Id);
        }
    }
}
