using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespatchersDto
    {
        [XmlAttribute("TrucksCount")]
        public int TruckCount { get; set; }

        [XmlElement("DespatcherName")]        
        public string Name { get; set; }
        
        [XmlArray("Trucks")]
        public List<Trucks> Trucks { get; set; }
    }
    [XmlType("Truck")]
    public class Trucks
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; }
        [XmlElement("Make")]
        public string MakeType { get; set; }
    }
}
