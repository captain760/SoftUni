using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //The first line holds the length of the sequences – integer in range[1…100];
            //On the next lines until you receive " Clone them!" you will be receiving sequences(at least one) of ones and
            // zeroes, split by " !" (one or several).
            //Output
            //The output should be printed on the console and consists of two lines in the following format:
            //            " Best DNA sample { bestSequenceIndex} with sum: { bestSequenceSum}."
            //            "{ DNA sequence, joined by space}"
            int seqLength = int.Parse(Console.ReadLine());
            string sequence = "";
            int curSecLength = 1;
            int bestCurSecLength = 1;
            int curSecIndex = 0;
            int bestCurSecIndex = 0;
            int curSum = 0;
            int sampleNo = 1;
            int bestSample = 1;
            int[] bestSequence = new int[seqLength + 3];
            int[] initialArray = Console.ReadLine().Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            while (sequence != "Clone them!")
            {
                
                if (initialArray.Length!=seqLength)
                {
                    break;
                }
                for (int i = 0; i < initialArray.Length; i++)
                {
                    for (int j = i+1; j < initialArray.Length; j++)
                    {
                        if ((initialArray[i] == initialArray[j])&& initialArray[i]==1)
                        {
                            curSecLength++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    curSecIndex = i;
                    if (curSecLength>bestCurSecLength)
                    {
                        bestCurSecLength = curSecLength;
                        bestCurSecIndex = curSecIndex;
                    }
                    if (initialArray[i] == 1)
                    {
                        curSum++;
                    }
                    curSecLength = 1;
                }
                
                if (bestCurSecLength > bestSequence[initialArray.Length + 1])
                {
                    bestSequence[initialArray.Length] = bestCurSecIndex;
                    bestSequence[initialArray.Length + 1] = bestCurSecLength;
                    bestSequence[initialArray.Length + 2] = curSum;
                    bestSample = sampleNo;
                    for (int i = 0; i < initialArray.Length; i++)
                    {
                        bestSequence[i] = initialArray[i];
                    }
                }
                else if (bestCurSecLength == bestSequence[initialArray.Length + 1] && bestCurSecIndex < bestSequence[initialArray.Length])
                {
                    bestSequence[initialArray.Length] = bestCurSecIndex;
                    bestSequence[initialArray.Length + 1] = bestCurSecLength;
                    bestSequence[initialArray.Length + 2] = curSum;
                    bestSample = sampleNo;
                    for (int i = 0; i < initialArray.Length; i++)
                    {
                        bestSequence[i] = initialArray[i];
                    }
                }
                else if (bestCurSecLength == bestSequence[initialArray.Length + 1] && bestCurSecIndex == bestSequence[initialArray.Length] && curSum>bestSequence[initialArray.Length+2])
                {
                    bestSequence[initialArray.Length] = bestCurSecIndex;
                    bestSequence[initialArray.Length + 1] = bestCurSecLength;
                    bestSequence[initialArray.Length + 2] = curSum;
                    bestSample = sampleNo;
                    for (int i = 0; i < initialArray.Length; i++)
                    {
                        bestSequence[i] = initialArray[i];
                    }
                }
                curSum = 0;
                bestCurSecLength = 1;
                sequence =  Console.ReadLine();
                if (sequence!= "Clone them!")
                {
                    initialArray = sequence.Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    sampleNo++;
                }
                
            }
            if (seqLength > 0 && initialArray.Length == seqLength)
            {
                Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSequence[initialArray.Length + 2]}.");
                for (int i = 0; i < initialArray.Length; i++)
                {
                    Console.Write(bestSequence[i] + " ");
                }
            }
        }
    }
}
