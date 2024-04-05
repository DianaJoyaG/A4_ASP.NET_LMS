using System;
using System.ComponentModel.DataAnnotations;

namespace LMS_project_5.Models
{
    public class Borrowing
    {
        [Key]
        public int IDBorrowing { get; set; } // Unique identifier for each borrowing instance

        [Required]
        public int IDBook { get; set; } // Foreign key to the Book entity

        [Required]
        public int IDReader { get; set; } // Foreign key to the Reader entity

        [Required]
        [DataType(DataType.Date)]
        public DateTime BorrowedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnedDate { get; set; } // Nullable, assuming the book might not have been returned yet
    }
}
