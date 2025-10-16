using BookZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookZone.Services
{
    public class LanguagesServices : ILanguagesServices
    {
        private readonly ApplicationDbContext _context;
        public LanguagesServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetLanguages()
        {
            return _context.Languges
                        .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
                        .OrderBy(l => l.Text)
                        .AsNoTracking()
                        .ToList();
        }
    }
}
