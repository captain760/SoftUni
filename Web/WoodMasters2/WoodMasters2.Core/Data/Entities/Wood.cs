using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Data.Entities
{
    public class Wood
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; } = null!;
       
       
        public virtual List<MasterPieceWood> MasterPiecesWoods { get; set; } = new List<MasterPieceWood>();
        public virtual List<WoodStain> WoodsStains { get; set; } = new List<WoodStain>();
        public virtual List<WoodSupplier> WoodsSuppliers { get; set; } = new List<WoodSupplier>();
    }
}
