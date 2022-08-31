using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }
        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }
        [XmlElement("Key")]
        [Required]
        [RegularExpression(@"^([A-Z\d]{4})-([A-Z\d]{4})-([A-Z\d]{4})$")]
        [MaxLength(14)]
        public string ProductKey { get; set; }
        [XmlElement("Card")]
        [Required]
        [RegularExpression(@"^(\d{4}) (\d{4}) (\d{4}) (\d{4})$")]
        [MaxLength(19)]
        public string CardNumber { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }
        
       
    }
}
