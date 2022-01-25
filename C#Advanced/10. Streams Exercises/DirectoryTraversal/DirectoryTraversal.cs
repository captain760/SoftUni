namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] filesInDir = Directory.GetFiles(inputFolderPath);
            DirectoryInfo dir = new DirectoryInfo(inputFolderPath);
            FileInfo[] infos = dir.GetFiles("*");
            
            Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>();
            foreach (var info in infos)
            {
                string name = info.Name;
                string extension = info.Extension;
                double size = 1.0*info.Length/1024;
                if (!data.ContainsKey(extension))
                {
                    data.Add(extension, new Dictionary<string, double>());
                }
                data[extension].Add(name, size);

            }
            StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\report.txt");
            using (writer)
            {
                foreach (var item in data.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
                {
                    writer.WriteLine(item.Key);
                    foreach (var file in item.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value:f3}kb");
                    }
                }
            }
            
            
            
            return null; 
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            
        }

    }
}
