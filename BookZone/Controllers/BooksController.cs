using Microsoft.AspNetCore.Mvc;

namespace BookZone.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Creat()
        {
            return View();
        }
    }
}
