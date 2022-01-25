
using System.IO;
namespace LineNumbers
{
    using System.Linq;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            string[] newLines = new string[lines.Length];
            int letters = 0;
            int marks = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                letters = lines[i].Count(char.IsLetter);
                marks = lines[i].Count(char.IsPunctuation);
                newLines[i] = $"Line {i + 1}: {lines[i]} ({letters})({marks})";
            }
            File.WriteAllLines(outputFilePath, newLines);
        }
    }
}
