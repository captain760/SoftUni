namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = System.Console.ReadLine();
            int age = int.Parse(System.Console.ReadLine());
            if (age <= 15)
            {
                Child child = new Child(name, age);
                System.Console.WriteLine(child);
            }
            else
            {
                Person person = new Person(name, age);
                System.Console.WriteLine(person);
            }

        }
    }
}