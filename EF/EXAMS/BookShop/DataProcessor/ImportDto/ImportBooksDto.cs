﻿using BookShop.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class ImportBooksDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
        [XmlElement("Genre")]
        [Required]
        public int Genre { get; set; }
        [XmlElement("Price")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
        [XmlElement("Pages")]
        [Range(50, 5000)]
        public int Pages { get; set; }
        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }
    }
}
