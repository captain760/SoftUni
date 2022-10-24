using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Models;

namespace WoodMasters2.Core.Contracts
{
    /// <summary>
    /// Handle MasterPiece data
    /// </summary>
    public interface IMasterPieceService
    {
        
        /// <summary>
        /// Gets all MasterPieces
        /// </summary>
        /// <returns>List of MasterPieces</returns>
        Task<IEnumerable<MasterPieceViewModel>> GetAll();
    }
}

