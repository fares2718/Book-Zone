using BookZone.Models;

namespace BookZone.Services
{
    public interface IAuthorServices
    {
        public Author GetAuthor(string name);
    }
}
