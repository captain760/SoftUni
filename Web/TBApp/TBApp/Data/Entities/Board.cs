using System.ComponentModel.DataAnnotations;
using static TBApp.Data.DataConstants.Board;

namespace TBApp.Data.Entities
{
    public class Board
    {
        public Board()
        {
            Tasks = new List<Task>();
        }
        [Key]
        public int Id { get; init; }
        [Required]
        [StringLength(BoardNameMaxLength)]
        public string Name { get; init; }
        public virtual IEnumerable<Task> Tasks { get; set; }
    }
}
