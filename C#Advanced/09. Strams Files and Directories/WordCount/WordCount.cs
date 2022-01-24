namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {

            Dictionary<string, int> dictOcc = new Dictionary<string, int>();
            StreamReader WordReader = new StreamReader(wordsFilePath);
            using (WordReader)
            {

                string[] words = WordReader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        string word = words[i];
                        StreamReader textReader = new StreamReader(textFilePath);
                        using (textReader)
                        {
                            string text = textReader.ReadToEnd();
                            int occurrances = 0;
                            char[] delimiters = new char[] { '!', '?', '-', '.', ',', ' ', '\r', '\n' };
                            string[] textWords = text.ToLower().Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToArray();


                            for (int j = 0; j < textWords.Length; j++)
                            {
                                if (textWords[j] == word.ToLower())
                                {
                                    occurrances++;
                                }
                            }
                            if (!dictOcc.ContainsKey(word))
                            {
                                dictOcc.Add(word, occurrances);
                            }
                            else
                            {
                                int pastOccurrances = dictOcc[word];
                                dictOcc[word] = pastOccurrances + occurrances;
                            }
                        }
                    }
                    foreach (var item in dictOcc.OrderByDescending(x=>x.Value))
                    {
                        writer.WriteLine($"{item.Key} - {item.Value}");
                    }
                    
                }
            }

        }
    }
}
