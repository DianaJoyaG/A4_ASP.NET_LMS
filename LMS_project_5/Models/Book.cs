using System.ComponentModel.DataAnnotations;
namespace LMS_project_5.Models
{
    public class Book
    {
        [Key]
        public int IDBook { get; set; } // primary key of the entity In database design, does not requiere a data annotation

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; } 

        [Required]
        [StringLength(100, ErrorMessage = "Author name cannot be longer than 100 characters.")]
        public string Author { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description name cannot be longer than 100 characters.")]
        public string Description { get; set; }

    }
}
