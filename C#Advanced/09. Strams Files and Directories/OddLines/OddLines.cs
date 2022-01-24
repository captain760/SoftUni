
namespace OddLines
{
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (line != null)
                    {
                        if (lineNumber % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        lineNumber++;
                        line = reader.ReadLine();
                    }

                }

            }
        }
    }
}
