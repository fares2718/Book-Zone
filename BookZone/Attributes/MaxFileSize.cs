using System.ComponentModel.DataAnnotations;

namespace BookZone.Attributes
{
    public class MaxFileSize : ValidationAttribute
    {
        private readonly int _maxSize;

        public MaxFileSize(int maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                if (file.Length < _maxSize)
                    return new ValidationResult($"Maximum allowed size is {_maxSize} bytes");
            }
            return ValidationResult.Success;
        }
    }
}
    
