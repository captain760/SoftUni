using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Article
    {
        private string title_;
        private string content_;
        private string author_;
        public Article()
        {
            Title = title_;
            Content = content_;
            Author = author_;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> artList = new List<Article>();
            int numArticles = int.Parse(Console.ReadLine());
            for (int i = 0; i < numArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article CurrArticle = new Article();
                CurrArticle.Title = input[0];
                CurrArticle.Content = input[1];
                CurrArticle.Author = input[2];
                artList.Add(CurrArticle);
            }
            string sortingCmd = Console.ReadLine();
            List<Article> sortedList = new List<Article>();
            if (sortingCmd == "title")
            {
                sortedList = artList.OrderBy(x => x.Title).ToList();
            }
            else if (sortingCmd == "content")
            {
                sortedList = artList.OrderBy(x => x.Content).ToList();
            }
            else if (sortingCmd == "author")
            {
                sortedList = artList.OrderBy(x => x.Author).ToList();
            }
            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
