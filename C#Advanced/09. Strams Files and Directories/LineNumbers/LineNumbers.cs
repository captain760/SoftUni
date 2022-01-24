namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                int lineNumber = 0;
                string currentLine = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (currentLine != null)
                    {
                        writer.WriteLine($"{lineNumber + 1}. {currentLine}");
                        lineNumber++;
                        currentLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
