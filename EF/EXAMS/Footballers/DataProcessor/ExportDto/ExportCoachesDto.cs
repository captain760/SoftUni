using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    
    public class ExportCoachesDto
    {
        public ExportCoachesDto()
        {
            Footballers = new List<ExportFoosDto>();
        }
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlElement("CoachName")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [XmlArray("Footballers")]
        public List<ExportFoosDto> Footballers { get; set; }
    }
}
