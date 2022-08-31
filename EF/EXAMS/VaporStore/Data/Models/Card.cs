using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
            this.Purchases = new HashSet<Purchase>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^(\d{4}) (\d{4}) (\d{4}) (\d{4})$")]
        [MaxLength(19)]
        public string Number { get; set; }
        [Required]
        [RegularExpression(@"^(\d{3})$")]
        [MaxLength(3)]
        public string Cvc { get; set; }
        [Required]
        public CardType Type { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [Required]
        public virtual User User { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
