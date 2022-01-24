using System.Collections.Generic;
using System.IO;
namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            string[] searchBytes = File.ReadAllLines(bytesFilePath);
            byte[] allBytes = File.ReadAllBytes(binaryFilePath);
            List<byte> occurances = new List<byte>();
            for (int i = 0; i < allBytes.Length; i++)
            {
                for (int j = 0; j < searchBytes.Length; j++)
                {
                    if (searchBytes[j].Contains((char)allBytes[i]))
                    {
                        occurances.Add(allBytes[i]);
                    }
               
                }
            }
            File.WriteAllBytes(outputPath, occurances.ToArray());
        }
    }
}
