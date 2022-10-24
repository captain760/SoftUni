using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Data.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;
        public virtual List<WoodSupplier> WoodsSuppliers { get; set; } = new List<WoodSupplier>();
    }
}
