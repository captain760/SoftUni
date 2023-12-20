namespace Exam.Categorization
{
    public class Category
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public int Depth { get; set; }

        public Category(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Depth = 0;
        }
        public override string ToString()
        {
            return Id;
        }
    }
}
