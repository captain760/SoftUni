using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = System.Console.ReadLine();
            while (input != "Beast!")
            {
                string type = input;
                if (string.IsNullOrEmpty(type))
                {
                    //throw new ArgumentNullException("Invalid input!");
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                string[] stringElements = System.Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = stringElements[0];
                if (string.IsNullOrEmpty(name))
                {
                    //throw new ArgumentNullException("Invalid input!");
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                var validAge = int.TryParse(stringElements[1], out int age);
                if (!validAge || age < 0)
                {
                    //throw new InvalidOperationException("Invalid input!");
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                string gender = stringElements[2];
                if (string.IsNullOrEmpty(gender))
                {
                    //throw new ArgumentNullException("Invalid input!");
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                switch (type)
                {
                    case "Cat":
                        {
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(type);
                            Console.WriteLine(cat.ToString());
                            Console.WriteLine(cat.ProduceSound());
                            break;
                        }
                    case "Dog":
                        {
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(type);
                            Console.WriteLine(dog.ToString());
                            Console.WriteLine(dog.ProduceSound());
                            break;
                        }
                    case "Frog":
                        {
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(type);
                            Console.WriteLine(frog.ToString());
                            Console.WriteLine(frog.ProduceSound());
                            break;
                        }
                    case "Kitten":
                        {
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine(type);
                            Console.WriteLine(kitten.ToString());
                            Console.WriteLine(kitten.ProduceSound());
                            break;
                        }
                    case "Tomcat":
                        {
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(type);
                            Console.WriteLine(tomcat.ToString());
                            Console.WriteLine(tomcat.ProduceSound());
                            break;
                        }
                }
                input = Console.ReadLine();
            }
        }
    }
}
