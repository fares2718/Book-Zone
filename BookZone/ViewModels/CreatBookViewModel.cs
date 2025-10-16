using BookZone.Attributes;
using BookZone.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookZone.ViewModels
{
    public class CreatBookViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(250)]
        [Display(Name = "Author")]
        public string AuthorName { get; set; } = string.Empty ;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories = Enumerable.Empty<SelectListItem>();
        [Display(Name ="Supported Languages")]
        public List<int> SelectedLanguages { get; set; } = default!;
        public IEnumerable<SelectListItem> Languages = Enumerable.Empty<SelectListItem>();
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [AllowedExtentions(FileSettings.AllowedExtentions)]
        public IFormFile Cover { get; set; } = default!;
    }
}
