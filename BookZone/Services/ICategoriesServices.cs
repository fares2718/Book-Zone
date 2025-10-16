using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookZone.Services
{
    public interface ICategoriesServices
    {
        IEnumerable<SelectListItem> GetCategories();
    }
}
