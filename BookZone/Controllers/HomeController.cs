using System.Diagnostics;
using BookZone.Models;
using BookZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookZone.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookServices _services;

        public HomeController(IBookServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var book = await _services.GetAll();
            return View(book);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
