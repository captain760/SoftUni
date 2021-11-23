using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexKey = @"^@#+(?<barcode>[A-Z][A-Z a-z0-9]{4,}[A-Z])@#+$";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string productGroup = "";
                if (Regex.IsMatch(input, regexKey))
                {
                    Match barcode = Regex.Match(input, regexKey);
                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (Char.IsDigit(barcode.ToString()[j]))
                        {
                            productGroup += barcode.ToString()[j];
                        }
                    }
                    if (productGroup == "")
                    {
                        productGroup = "00";
                    }
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
                
            }
            

        }
    }
}
