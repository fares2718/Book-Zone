using BookZone.Data;
using BookZone.Models;
using BookZone.Servieces;
using BookZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookZone.Controllers
{
    public class BooksController : Controller
    {
        private readonly CategoriesServices _categoriesServices;
        private readonly LanguagesServices _languagesServices;

        public BooksController(CategoriesServices categoriesServices, LanguagesServices languagesServices)
        {
            _categoriesServices = categoriesServices;
            _languagesServices = languagesServices;
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
