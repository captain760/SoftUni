using System.ComponentModel.DataAnnotations;
using static TBApp.Data.DataConstants.Task;

namespace TBApp.Data.Entities
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }
        public virtual Board Board { get; init; }
        [Required]
        public string OwnerId { get; set; }
        public virtual User Owner { get; init; }
    }
}
