using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data.Enums;

namespace WoodMasters2.Core.Data.Entities
{
    public class Master: IdentityUser
    {
       
        public Experience Experience { get; set; }
        public virtual List<MasterMasterPiece> MastersMasterPieces{ get; set; } = new List<MasterMasterPiece>();
        public virtual List<MasterAddress> MastersAddresses { get; set; } = new List<MasterAddress>();
    }
}
