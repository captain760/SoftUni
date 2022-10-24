using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Data.Entities
{
    public class WoodSupplier
    {
        [Required]
        [ForeignKey(nameof(Wood))]
        public int WoodId { get; set; }
        public virtual Wood Wood { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;
    }
}
