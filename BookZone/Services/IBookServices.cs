using BookZone.Models;
using BookZone.ViewModels;

namespace BookZone.Services
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetBookById(int Id);
        Task AddNewBook(CreatBookViewModel book);
    }
}
