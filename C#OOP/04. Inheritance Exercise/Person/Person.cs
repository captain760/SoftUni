using System.Text;

namespace Person
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                };
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");
            return sb.ToString().Trim();
        }
    }
}
