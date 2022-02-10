using System;
using System.Linq;

namespace _02._Pawn_Wars
{
    class Program
    {
        static void Main(string[] args)
        {           
            char[,] matrix = new char[8, 8];
            //creating chess board with indexes showing chess positions
            string[,] board = new string[8, 8];
            for (int i = 0; i < 8; i++)
            {
                char letter = '`';
                for (int j = 0; j < 8; j++)
                {
                    letter = (char)(letter + 1);
                    board[i, j] = $"{letter}{8 - i}";
                }
            }
            //initialization
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 7;
            int blackCol = 7;
            //reading the matrix
            for (int i = 0; i < 8; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = row[j];
                    if (row[j] == 'w')
                    {
                        whiteRow = i;
                        whiteCol = j;
                    }
                    if (row[j] == 'b')
                    {
                        blackRow = i;
                        blackCol = j;
                    }
                }
            }
            //main logic
            bool whiteTurn = true;
            while (whiteRow>0 && blackRow<7)
            {
               
                if (whiteTurn && whiteRow == blackRow + 1 && (whiteCol == blackCol + 1  || whiteCol == blackCol - 1))
                {
                    Console.WriteLine($"Game over! White capture on {board[blackRow,blackCol]}.");
                    return;
                }
                if (!whiteTurn && whiteRow == blackRow + 1 && (whiteCol == blackCol - 1 || whiteCol == blackCol + 1)) 
                {
                    Console.WriteLine($"Game over! Black capture on {board[whiteRow, whiteCol]}.");
                    return;
                }
                if (whiteTurn)
                {
                    whiteRow--;
                    whiteTurn = false;
                }
                else
                {
                    blackRow++;
                    whiteTurn = true;
                }
            }
            //logic when the pawn becomes a Queen
            if (whiteRow == 0)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {board[whiteRow,whiteCol]}.");
                return;
            }
            if (blackRow == 7)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {board[blackRow, blackCol]}.");
                return;
            }
        }
    }
}
