using System;

namespace _07_VendingMashine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coin;
            string product;
            double sum = 0;
            bool lackOfMoney = false;
            
            do
            {
                coin = Console.ReadLine();
                switch (coin)
                {
                    case "0.1": sum += 0.1;  break;
                    case "0.2": sum += 0.2; break;
                    case "0.5": sum += 0.5; break;
                    case "1": sum += 1; break;
                    case "2": sum += 2; break;
                    case "Start":break;
                    default:
                        Console.WriteLine($"Cannot accept {coin}");
                        break;
                }
            } while (coin != "Start"); 
            do
            {
                product = Console.ReadLine();
                switch (product)
                {
                    case "Nuts":
                        {
                            if (sum >= 2)
                            {
                                sum -= 2;
                            }
                            else lackOfMoney=true;
                        }   
                            break;
                    case "Water":
                        {
                            if (sum >= 0.7)
                            {
                                sum -= 0.7;
                            }
                            else lackOfMoney = true;
                        }
                         break;
                    case "Crisps":
                        {
                            if (sum >= 1.5)
                            {
                                sum -= 1.5;
                            }
                            else lackOfMoney = true;
                        }
                         break;
                    case "Soda":
                        {
                            if (sum >= 0.8)
                            {
                                sum -= 0.8;
                            }
                            else lackOfMoney = true;
                        }
                         break;
                    case "Coke":
                        {
                            if (sum >= 1)
                            {
                                sum -= 1;
                            }
                            else lackOfMoney = true;
                        }
                         break;
                    case "End":break;
                    default:
                        Console.WriteLine($"Invalid product");
                        break;
                }
                if ((!lackOfMoney && product !="End") && (product=="Nuts" || product== "Water" || product=="Crisps" || product=="Soda" || product=="Coke"))
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else if (lackOfMoney && product !="End")
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                lackOfMoney = false;
            } while (product != "End" && sum >= 0);
            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}
