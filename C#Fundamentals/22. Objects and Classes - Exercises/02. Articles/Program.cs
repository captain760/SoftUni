using System;

namespace _02._Articles
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

        public void Edit(string content)
        {
            Content = content;
        }
        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Article art = new Article();
            art.Title = input[0];
            art.Content = input[1];
            art.Author = input[2];
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] cmd = Console.ReadLine().Split(": ");
                if (cmd[0] == "Edit")
                {
                    art.Edit(cmd[1]);
                }
                else if (cmd[0] == "ChangeAuthor")
                {
                    art.ChangeAuthor(cmd[1]);
                }
                else if (cmd[0] == "Rename")
                {
                    art.Rename(cmd[1]);
                }
            }
            Console.WriteLine(art);
        }
    }
}
