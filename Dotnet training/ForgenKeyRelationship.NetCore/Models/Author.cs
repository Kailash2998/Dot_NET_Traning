using System.ComponentModel.DataAnnotations;

namespace ForgenKeyRelationship.NetCore.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [RegularExpression(@"^(?!\s+$)[a-zA-Z\s]*$", ErrorMessage = "Name cannot contain numbers, special characters, or blank space")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Bio cannot exceed 1000 characters")]
        [MinLength(3, ErrorMessage = "Bio must be at least 200 characters")]
        [RegularExpression(@"^(?!\s+$)[a-zA-Z\s]*$", ErrorMessage = "Bio cannot contain numbers, special characters, or blank space")]
        public string Bio { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
