
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
        }
        [Key]
        public int PlayerId { get; set; }
        [Required]
        [MaxLength(GeneralConstants.PlayerNameLength)]
        public string Name { get; set; }
        [Required]
        public byte SquadNumber { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(Position))]  
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        [Required]
        public bool IsInjured { get; set; }
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
