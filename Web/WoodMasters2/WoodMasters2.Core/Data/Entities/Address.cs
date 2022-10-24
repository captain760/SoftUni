using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Data.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(85)]
        public string PlaceName { get; set; } = null!;
        [Required]
        [StringLength(56)]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        [Required]
        public virtual Country Country { get; set; } = null!;
        public virtual List<MasterAddress> MastersAddresses { get; set; } = new List<MasterAddress>();
    }
}
