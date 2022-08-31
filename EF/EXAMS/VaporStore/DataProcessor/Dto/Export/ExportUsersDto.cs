using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class ExportUsersDto
    {
        [XmlArray("Purchases")]
        public List<ExportPurchaseDto> Purchases { get; set; }
        [XmlAttribute("username")]
        public string Username { get; set; }
        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }

    [XmlType("Purchase")]
    public class ExportPurchaseDto
    {
        [XmlElement("Card")]
        public string CardNumber { get; set; }
        [XmlElement("Cvc")]
        public string CardCvc { get; set; }
        [XmlElement("Date")]
        public string PurDate { get; set; }
        [XmlElement("Game")]
        public ExportGameDto GameDetails { get; set; }
    }
    public class ExportGameDto
    {
        [XmlAttribute("title")]
        public string GameName { get; set; }
        [XmlElement("Genre")]
        public string Genre { get; set; }
        [XmlElement("Price")]
        public decimal GamePrice { get; set; }
    }
}
