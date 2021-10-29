using System;

namespace _03_GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            bool notAffordable = false;
            double ballance = double.Parse(Console.ReadLine());
            double initialBallance = ballance;
            string gameName = Console.ReadLine();

            while (gameName != "Game Time")
            {
                switch (gameName)
                {
                    //OutFall 4                     $39.99
                    //CS: OG                        $15.99
                    //Zplinter Zell                 $19.99
                    //Honored 2                     $59.99
                    //RoverWatch                    $29.99
                    //RoverWatch Origins Edition    $39.99
                    case "OutFall 4":
                        if (ballance >= 39.99)
                        {
                            ballance -= 39.99;
                            Console.WriteLine($"Bought OutFall 4");
                        }
                        else notAffordable = true;
                        break;
                    case "CS: OG":
                        if (ballance >= 15.99)
                        {
                            ballance -= 15.99;
                            Console.WriteLine($"Bought CS: OG");
                        }
                        else
                            notAffordable  = true;
                        break;
                    case "Zplinter Zell":
                        if (ballance >= 19.99)
                        {
                            ballance -= 19.99;
                            Console.WriteLine($"Bought Zplinter Zell");
                        }
                        else notAffordable  = true;
                        break;
                    case "Honored 2":
                        if (ballance >= 59.99)
                        {
                            ballance -= 59.99;
                            Console.WriteLine($"Bought Honored 2");
                        }
                        else notAffordable  = true;
                        break;
                    case "RoverWatch":
                        if (ballance >= 29.99)
                        {
                            ballance -= 29.99;
                            Console.WriteLine($"Bought RoverWatch");
                        }
                        else notAffordable = true;
                        break;
                    case "RoverWatch Origins Edition":
                        if (ballance >= 39.99)
                        {
                            ballance -= 39.99;
                            Console.WriteLine($"Bought RoverWatch Origins Edition");
                        }
                        else notAffordable = true;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                if (notAffordable)
                {
                    Console.WriteLine("Too Expensive");
                }
                if (ballance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                gameName = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${(initialBallance-ballance):f2}. Remaining: ${ballance:F2}");
        }
    }
}
