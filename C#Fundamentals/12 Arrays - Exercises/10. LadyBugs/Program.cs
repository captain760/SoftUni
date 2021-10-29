using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
           
                int[] initialArray = new int[size];
                int[] bugsIndexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int i = 0; i < bugsIndexes.Length; i++)
                {
                    if (bugsIndexes[i] >= 0 && bugsIndexes[i] < size)
                    {
                        initialArray[bugsIndexes[i]] = 1;
                    }
                }
                string com = Console.ReadLine();
                while (com != "end")
                {
                    string[] flyCom = com.Split();
                    int currentIndex = int.Parse(flyCom[0]);
                    int fly = int.Parse(flyCom[2]);
                    int shift = 0;
                    if (currentIndex >= 0 && currentIndex < initialArray.Length && fly != 0)
                    {
                        if (flyCom[1] == "right")
                        {
                            shift = fly;
                        }
                        else if (flyCom[1] == "left")
                        {
                            shift = -fly;
                        }
                        int nextIndex = currentIndex + shift;
                    if (initialArray[currentIndex] == 1)
                    {
                        initialArray[currentIndex] = 0;

                        while (nextIndex < initialArray.Length && nextIndex >= 0)
                        {
                            if (initialArray[nextIndex] == 1)
                            {
                                nextIndex += shift;
                                if (nextIndex >= initialArray.Length || nextIndex < 0)
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                initialArray[nextIndex] = 1;
                                break;
                            }


                        }
                    }
                    }
                    com = Console.ReadLine();

                }
                for (int i = 0; i < initialArray.Length; i++)
                {


                    Console.Write(initialArray[i] + " ");
                }
            
        }
    }
}
