using BookZone.Data;
using BookZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookZone.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Creat()
        {
            CreatBookViewModel viewModel = new()
            {
                Categories = _context.Categories
                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                        .OrderBy(c => c.Text)
                        .ToList(),
                Languages = _context.Languges
                        .Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Name })
                        .OrderBy(l => l.Text)
                        .ToList()
            };
            return View(viewModel);
        }
    }
}
