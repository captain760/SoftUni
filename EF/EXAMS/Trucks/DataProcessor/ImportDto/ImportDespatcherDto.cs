using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }
        [XmlElement("Position")]
        public string Position { get; set; }
        [XmlArray("Trucks")]
        public  List<ImportTruck> Trucks { get; set; }
    }
    [XmlType("Truck")]
    public class ImportTruck
    {
        [XmlElement("RegistrationNumber")]
        [Required]
        [MaxLength(8)]
        [RegularExpression(@"^([A-Z]{2})(\d{4})([A-Z]{2})$")]
        public string RegistrationNumber { get; set; }
        [XmlElement("VinNumber")]
        [Required]
        [MaxLength(17)]
        public string VinNumber { get; set; }
        [XmlElement("TankCapacity")]
        [Range(950, 1420)]
        public int? TankCapacity { get; set; }
        [XmlElement("CargoCapacity")]
        [Range(5000, 29000)]
        public int? CargoCapacity { get; set; }
        [XmlElement("CategoryType")]
        [Required]
        //[EnumDataType(typeof(CategoryType))]
        public int CategoryType { get; set; }
        [Required]
        //[EnumDataType(typeof(MakeType))]
        public int MakeType { get; set; }
    }
}
