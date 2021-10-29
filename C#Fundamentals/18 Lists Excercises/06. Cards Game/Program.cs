using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //            You will be given two hands of cards, which will be represented by integers.Assume each one is held by a different
            //player.You have to find which one has the winning deck. You start from the beginning of both hands of cards.
            //Compare the cards from the first deck to the cards from the second deck.The player, who holds the more powerful
            //card on the current iteration, takes both cards and puts them at the back of his hand - the second player&#39;s card is
            //placed last, and the first person&#39;s card (the winning one) comes after it (second to last). If both players&#39; cards have
            //the same values -no one wins, and the two cards must be removed from both hands.The game is over when only
            //one of the decks is left without any cards. You have to display the result on the console and the sum of the
            //remaining cards: &quot;{ First / Second} player wins!Sum: {sum}"
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();
            int counter = 0;
            while (first.Count != 0 && second.Count != 0)
            {
                
                
                if (first[counter] > second[counter])
                {
                    first.Add(first[counter]);
                    first.Add(second[counter]);
                    first.RemoveAt(counter);
                    second.RemoveAt(counter);
                   
                }
                else if (first[counter] < second[counter])
                {
                    second.Add(second[counter]);
                    second.Add(first[counter]);
                    first.RemoveAt(counter);
                    second.RemoveAt(counter);
                   
                }
                else
                {
                    first.RemoveAt(counter);
                    second.RemoveAt(counter);
                    
                }

            }

            int sum = 0;
            if (first.Count == 0)
            {
                for (int i = 0; i < second.Count; i++)
                {
                    sum += second[i];
                }
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            else if (second.Count == 0)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    sum += first[i];
                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
        }
    }
}
