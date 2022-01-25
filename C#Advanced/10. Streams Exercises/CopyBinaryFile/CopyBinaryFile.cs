using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream fsin = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] input = new byte[fsin.Length];
                
                     fsin.Read(input, 0, input.Length);
                    
                using (FileStream fsout = new FileStream(outputFilePath, FileMode.Create))
                {
                    fsout.Write(input, 0, input.Length);
                }
            }
        }

    }
}

