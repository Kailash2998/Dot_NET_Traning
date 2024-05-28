using System.ComponentModel.DataAnnotations;

namespace CrudUsingWebAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Product name can't be longer than 100 characters")]
        [MinLength(3, ErrorMessage = "Product Name must be at least 3 characters")]
        [RegularExpression(@"^(?!\s+$)[a-zA-Z\s]*$", ErrorMessage = "Product Name cannot contain numbers, special characters, or blank space")]
        public string ProductName { get; set; }

        [StringLength(500, ErrorMessage = "Product description can't be longer than 500 characters")]
        [MinLength(3, ErrorMessage = "Product description must be at least 3 characters")]
        [RegularExpression(@"^(?!\s+$)[a-zA-Z\s]*$", ErrorMessage = "Product description cannot contain numbers, special characters, or blank space")]
        public string ProductDescription { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Product price must be between 0.01 and 10000.00")]
        public decimal ProductPrice { get; set; }
    }
}
