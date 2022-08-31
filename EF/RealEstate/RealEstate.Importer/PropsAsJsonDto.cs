using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Importer
{
    public class PropsAsJsonDto
    {
        public string Url { get; set; }

        public int Size { get; set; }

        public int YardSize { get; set; }

        public int Floor { get; set; }

        public int TotalFloors { get; set; }

        public string District { get; set; }

        public int Year { get; set; }

        public string Type { get; set; }

        public string BuildingType { get; set; }

        public int Price { get; set; }
    }
}
//"Url": "https://www.imot.bg/pcgi/imot.cgi?act=5&adv=1j160517462630067&slink=6hsfmi&f1=1",
//    "Size": 23,
//    "YardSize": 950,
//    "Floor": 0,
//    "TotalFloors": 0,
//    "District": "град София, Горна баня",
//    "Year": 1975,
//    "Type": "КЪЩА",
//    "BuildingType": "Тухла",
//    "Price": 44888