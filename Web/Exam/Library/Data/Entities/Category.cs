using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Data.DataConstants.Category.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
