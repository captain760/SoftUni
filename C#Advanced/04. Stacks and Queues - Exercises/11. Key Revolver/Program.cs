using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(bullets);
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(locks);
            int intelliValue = int.Parse(Console.ReadLine());
            int bulletsShot = 0;
            int totalbulletsShot = 0;
            while (stack.Count>0 && queue.Count>0)
            {
                if (stack.Peek()<=queue.Peek())
                {
                    Console.WriteLine("Bang!");
                    stack.Pop();
                    queue.Dequeue();
                    bulletsShot++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stack.Pop();
                    bulletsShot++;
                }
                totalbulletsShot++;
                if (bulletsShot==barrelSize && stack.Count>0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsShot = 0;
                }
                
            }
            if (stack.Count==0 && queue.Count>0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queue.Count}");
            }
            if (queue.Count==0)
            {
                Console.WriteLine($"{stack.Count} bullets left. Earned ${intelliValue-totalbulletsShot*bulletPrice}");
            }
        }
    }
}
