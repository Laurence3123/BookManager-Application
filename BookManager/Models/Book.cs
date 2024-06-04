using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public decimal Wri_IN { get; set; }
        public decimal Bcost { get; set; }
        public decimal Wcost { get; set; }
        public int Sold { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
