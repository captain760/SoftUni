using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.DataConstants.Post;

namespace ForumApp.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = 10, ErrorMessage = "The length should be between 10 and 50 symbols")]
        public string Title { get; set; }
        [Required]
        [StringLength(ContentMaxLength, MinimumLength = 30, ErrorMessage = $"The length should be between 30 and 1500 symbols")]
        public string Content { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
