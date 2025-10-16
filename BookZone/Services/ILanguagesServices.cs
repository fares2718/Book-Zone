using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookZone.Services
{
    public interface ILanguagesServices
    {
        IEnumerable<SelectListItem> GetLanguages();
    }
}
