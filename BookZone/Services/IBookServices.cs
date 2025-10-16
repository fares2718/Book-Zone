using BookZone.Models;
using BookZone.ViewModels;

namespace BookZone.Services
{
    public interface IBookServices
    {
        public Task AddNewBook(CreatBookViewModel book);
    }
}
