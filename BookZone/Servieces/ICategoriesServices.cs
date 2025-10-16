using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookZone.Servieces
{
    public interface ICategoriesServices
    {
        IEnumerable<SelectListItem> GetCategories();
    }
}
