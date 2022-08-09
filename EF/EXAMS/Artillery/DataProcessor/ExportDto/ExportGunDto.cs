using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportGunDto
    {
        [XmlAttribute("Manufacturer")]
        public string ManufacturerName { get; set; }
        [XmlAttribute("GunType")]
        public string GunType { get; set; }
        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }
        [XmlAttribute("BarrelLength")]
        public double BarrelLength { get; set; }
        [XmlAttribute("Range")]
        public int Range { get; set; }
        [XmlArray("Countries")]
        public List<CountryDto> Countries { get; set; }
    }

    [XmlType("Country")]
    public class CountryDto
    {
        [XmlAttribute("Country")]
        public string CountryName { get; set; }
        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }
    }
}
