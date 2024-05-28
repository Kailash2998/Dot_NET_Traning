using System;
using System.ComponentModel.DataAnnotations;

namespace ForgenKeyRelationship.NetCore.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters")]
        [RegularExpression(@"^(?!\s+$)[a-zA-Z\s]*$", ErrorMessage = "Title cannot contain numbers, special characters, or blank space")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(13, ErrorMessage = "ISBN must be exactly 13 characters", MinimumLength = 13)]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Publication Date is required")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 1000.00, ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters")]
        [MinLength(3, ErrorMessage = "Genre must be at least 3 characters")]
        [RegularExpression(@"^(?!\s+$)[a-zA-Z\s]*$", ErrorMessage = "Genre cannot contain numbers, special characters, or blank space")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        public int PublisherId { get; set; }

        // Navigation properties
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
