using BookZone.Data;
using BookZone.Models;
using BookZone.ViewModels;

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
            _imagesPath = $"{_webHostEnvironment.WebRootPath}/assets/images";
        }

        public async Task AddNewBook(CreatBookViewModel book)
        {
            string coverName = $"{Guid.NewGuid()}{Path.GetExtension(book.Cover.FileName)}";
            var path = Path.Combine(_imagesPath, coverName) ;
            using var stream = File.Create(path) ;
            await book.Cover.CopyToAsync(stream) ;
            stream.Dispose();
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
    }
}
