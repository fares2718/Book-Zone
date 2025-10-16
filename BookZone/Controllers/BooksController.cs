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

        public BooksController(ICategoriesServices categoriesServices, ILanguagesServices languagesServices, IAuthorServices authorServices)
        {
            _categoriesServices = categoriesServices;
            _languagesServices = languagesServices;
            _authorServices = authorServices;
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
                Categories = _categoriesServices.GetCategories(),
                Languages = _languagesServices.GetLanguages()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creat(CreatBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetCategories();
                model.Languages = _languagesServices.GetLanguages();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
