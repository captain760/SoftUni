using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(8)]
        [RegularExpression(@"^([A-Z]{2}\d{4}[A-Z]{2})$")]
        public string RegistrationNumber { get; set; }
        [Required]
        [MaxLength(17)]
        public string VinNumber { get; set; }
        [Required]
        [Range(950,1420)]
        public int TankCapacity { get; set; }
        [Range(5000,29000)]
        [Required]
        public int CargoCapacity { get; set; }
        [Required]
        [EnumDataType(typeof(CategoryType))]
        public CategoryType CategoryType { get; set; }
        [Required]
        [EnumDataType(typeof(MakeType))]
        public MakeType MakeType { get; set; }
        [Required]
        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }
        public virtual Despatcher Despatcher { get; set; }
        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
//•	Id – integer, Primary Key
//•	RegistrationNumber – text with length 8. First two characters are upper letters [A-Z], followed by four digits and the last two characters are upper letters [A-Z] again.
//•	VinNumber – text with length 17 (required)
//•	TankCapacity – integer in range[950…1420]
//•	CargoCapacity – integer in range[5000…29000]
//•	CategoryType – enumeration of type CategoryType, with possible values (Flatbed, Jumbo, Refrigerated, Semi) (required)
//•	MakeType – enumeration of type MakeType, with possible values (Daf, Man, Mercedes, Scania, Volvo) (required)
//•	DespatcherId – integer, foreign key(required)
//•	Despatcher – Despatcher 
//•	ClientsTrucks – collection of type ClientTruck
