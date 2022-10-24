using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Models
{
    /// <summary>
    /// MasterPiece Dto model
    /// </summary>
    public class MasterPieceViewModel
    {
        /// <summary>
        /// MasterPiece identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// MasterPiece name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// MasterPiece crafter
        /// </summary>
        public string Master { get; set; } = null!;
        /// <summary>
        /// MasterPiece width
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// MasterPiece length
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// MasterPiece thickness
        /// </summary>
        public double Depth { get; set; }
        /// <summary>
        /// MasterPiece image
        /// </summary>
        public string ImageURL { get; set; } = null!;
        /// <summary>
        /// MasterPiece wood type
        /// </summary>
        public string? WoodType { get; set; }
        /// <summary>
        /// MasterPiece craft type
        /// </summary>
        public string? Category { get; set; }
        /// <summary>
        /// MasterPiece price
        /// </summary>public string? Category { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// MasterPiece quantity available
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// MasterPiece users rating
        /// </summary>
        public decimal Rating { get; set; }
        


    }
}
