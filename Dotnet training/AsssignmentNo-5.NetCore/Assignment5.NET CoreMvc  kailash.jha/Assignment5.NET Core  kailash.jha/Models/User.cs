using System.ComponentModel.DataAnnotations;

namespace AsssignmentNo_5.NetCore.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [RegularExpression(@"^(?!\s+$)[a-zA-Z\s]*$", ErrorMessage = "Name cannot contain numbers, special characters or Blank space")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = default!;

        [Required(ErrorMessage = "Pincode is required")]
        [Range(100000, 999999, ErrorMessage = "Pincode must be a 6-digit number")]
        public int Pincode { get; set; }

        public bool IsActive { get; set; }
    }
}
