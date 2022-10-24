using System.ComponentModel.DataAnnotations;

using Library.Data.Entities;


namespace Library.Models
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(Data.DataConstants.Book.TitleMaxLength, MinimumLength = Data.DataConstants.Book.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(Data.DataConstants.Book.AuthorMaxLength, MinimumLength = Data.DataConstants.Book.AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(Data.DataConstants.Book.DescriptionMaxLength, MinimumLength = Data.DataConstants.Book.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.0", "10.0")]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
