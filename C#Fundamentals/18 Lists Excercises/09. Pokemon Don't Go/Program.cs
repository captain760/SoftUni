using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int index = int.Parse(Console.ReadLine());
            int sum = 0;
            int capturedValue;
            bool removal = false;
            while (pokemons.Count > 0)
            {
                if (index<0)
                {
                    index = 0;
                    removal = true;
                }
                if (index>=pokemons.Count)
                {
                    index = pokemons.Count - 1;
                    removal = true;
                }
                capturedValue = pokemons[index];
                sum += capturedValue;
                
                if (index == 0 && removal)
                {
                    pokemons[0] = pokemons[pokemons.Count - 1];
                    
                   
                    
                }
                else if (index == pokemons.Count-1 && removal)
                {
                    pokemons[pokemons.Count-1]= pokemons[0];
                    
                    
                    
                }
                else
                {
                    
                        pokemons.RemoveAt(index);
                    
                    
                }
                removal = false;
                if (pokemons.Count == 0)
                    {
                        break;
                    }
                for (int i = 0; i < pokemons.Count; i++)
                    {
                    if (pokemons[i]>capturedValue)
                    {
                        pokemons[i] -= capturedValue;
                    }
                    else
                    {
                        pokemons[i] += capturedValue;
                    }
                }
               //Console.WriteLine(string.Join(" ",pokemons));
                index = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }
    }
}
