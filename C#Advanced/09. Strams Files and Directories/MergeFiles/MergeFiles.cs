using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader firstFile = new StreamReader(firstInputFilePath);
            using (firstFile)
            {
                StreamReader secondFile = new StreamReader(secondInputFilePath);
                using (secondFile)
                {
                    string lineFirst = firstFile.ReadLine();
                    string lineSecond = secondFile.ReadLine();
                    StreamWriter writer = new StreamWriter(outputFilePath);
                    using (writer)
                    {
                        while (lineFirst != null && lineSecond != null)
                        {
                            if (lineFirst==null)
                            {
                                writer.WriteLine(lineSecond);
                            }
                            else if (lineSecond==null)
                            {
                                writer.WriteLine(lineFirst);
                            }
                            else
                            {
                                writer.WriteLine(lineFirst);
                                writer.WriteLine(lineSecond);
                            }
                            lineFirst = firstFile.ReadLine();
                            lineSecond = secondFile.ReadLine();
                        }
                    }
                    
                }
            }
        }
    }
}
