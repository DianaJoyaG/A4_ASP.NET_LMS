using System.ComponentModel.DataAnnotations;
namespace LMS_project_5.Models
{
    public class Reader
    {

        [Key]
        [Required]
        public int IDReader { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string NameReader { get; set; } = "";

    }
}
