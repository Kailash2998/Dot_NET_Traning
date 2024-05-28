using System.ComponentModel.DataAnnotations;

namespace CrudOperation.NetCore.Models
{
    /// <summary>
    /// create the model Class
    /// </summary>
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [NoNumbers(ErrorMessage = "Name cannot contain numbers")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [MinLength(10, ErrorMessage = "Description cannot exceed 10 characters")]
        [NoNumbers(ErrorMessage = "Description cannot contain numbers")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Stock quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be a non-negative number")]
        public int? StockQuantity { get; set; }
    }

    public class NoNumbersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();

                // Use regular expression to check if the string contains any numbers
                if (stringValue.Any(char.IsDigit))
                {
                    return new ValidationResult(ErrorMessage ?? "The field cannot contain numbers.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
