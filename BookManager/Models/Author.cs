using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string? AuthoName { get; set; }
        public DateTime DoB { get; set; }
        public DateTime DoJ { get; set; }
        public string? Sex { get; set; }
        public string? Lang1 { get; set; }
        public string? Lang2 { get; set; }
        public decimal Salary { get; set; }
    }
}
