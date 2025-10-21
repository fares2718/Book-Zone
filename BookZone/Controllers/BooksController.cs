using BookZone.Data;
using BookZone.Models;
using BookZone.Services;
using BookZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookZone.Controllers
{
    public class BooksController : Controller
    {
        private readonly ICategoriesServices _categoriesServices;
        private readonly ILanguagesServices _languagesServices;
        private readonly IAuthorServices _authorServices;
        private readonly IBookServices _bookServices;

        public BooksController(ICategoriesServices categoriesServices, ILanguagesServices languagesServices,
            IAuthorServices authorServices, IBookServices bookServices)
        {
            _categoriesServices = categoriesServices;
            _languagesServices = languagesServices;
            _authorServices = authorServices;
            _bookServices = bookServices;
        }

        public async Task<IActionResult> Index()
        {
           var books = await  _bookServices.GetAll();
            return View(books);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var book = await _bookServices.GetBookById(Id);
            if(book is null)
                return NotFound("Book Was Not Found");
            return View(book);
        }

        [HttpGet]
        public IActionResult Creat()
        {
            CreatBookViewModel viewModel = new()
            {
                Categories = _categoriesServices.GetCategories(),
                Languages = _languagesServices.GetLanguages()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creat(CreatBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetCategories();
                model.Languages = _languagesServices.GetLanguages();
                return View(model);
            }
            await _bookServices.AddNewBook(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
