using System.ComponentModel.DataAnnotations;

namespace ForgenKeyRelationship.NetCore.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [RegularExpression(@"^(?!\s+$)[a-zA-Z\s]*$", ErrorMessage = "Name cannot contain numbers, special characters, or blank space")]
        public string Name { get; set; }

        /*[Required(ErrorMessage = "Address is required")]
        [StringLength(300, ErrorMessage = "Address cannot exceed 300 characters")]
        [MinLength(50, ErrorMessage = "Address must be at least 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Address cannot contain special characters or blank space")]
        public string Address { get; set; }
*/
        [Required(ErrorMessage = "Address is required")]
        [StringLength(300, ErrorMessage = "Address cannot exceed 300 characters")]
        [MinLength(50, ErrorMessage = "Address must be at least 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$", ErrorMessage = "Address must contain only alphanumeric characters with single spaces")]
        public string Address { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
