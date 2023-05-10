using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FPTStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int TotalPage { get; set; }
        public DateTime PublishTime { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        [Display(Name = "Book Image")]
        public IFormFile? BookImage { get; set; }
    }
}
