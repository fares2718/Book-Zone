using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookZone.Servieces
{
    public interface ILanguagesServices
    {
        IEnumerable<SelectListItem> GetLanguages();
    }
}
