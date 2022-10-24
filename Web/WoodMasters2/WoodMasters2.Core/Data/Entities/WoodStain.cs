using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Data.Entities
{
    public class WoodStain
    {
        [Required]
        [ForeignKey(nameof(Wood))]
        public int WoodId { get; set; }
        public virtual Wood Wood { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Stain))]
        public int StainId { get; set; }
        public virtual Stain Stain { get; set; } = null!;
    }
}
