using System.ComponentModel.DataAnnotations;

namespace BookZone.Attributes
{
    public class AllowedExtentions : ValidationAttribute
    {
        private readonly string _allowedExtentions;

        public AllowedExtentions(string allowedExtentions)
        {
            _allowedExtentions = allowedExtentions;
        }

        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if(file is not null)
            {
                string ext = Path.GetExtension(file.FileName);
                bool isAllowed = _allowedExtentions.Split(',').Contains(ext,StringComparer.OrdinalIgnoreCase);
                if (!isAllowed)
                    return new ValidationResult($"Only {_allowedExtentions} are allowed");
            }
            return ValidationResult.Success;
        }
    }
}
