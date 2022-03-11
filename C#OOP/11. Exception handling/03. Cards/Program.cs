using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            string[] elements = Console.ReadLine()
                     .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < elements.Length; i++)
            {
                string[] symbol = elements[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string face = symbol[0];
                string suit = symbol[1];
                try
                {
                    cards.Add(CreateCard(face, suit));
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Invalid card!");
                    continue;
                }
            }
            foreach (var card in cards)
            {
                Console.Write(card.ToString() + " ");
            }
            Console.WriteLine();


        }

        private static Card CreateCard(string face, string suit)
        {
            Faces face1;
            switch (face)
            {
                case ("2"):
                    face1 = Faces.Two;
                    break;
                case ("3"):
                    face1 = Faces.Three;
                    break;
                case ("4"):
                    face1 = Faces.Four;
                    break;
                case ("5"):
                    face1 = Faces.Five;
                    break;
                case ("6"):
                    face1 = Faces.Six;
                    break;
                case ("7"):
                    face1 = Faces.Seven;
                    break;
                case ("8"):
                    face1 = Faces.Eight;
                    break;
                case ("9"):
                    face1 = Faces.Nine;
                    break;
                case ("10"):
                    face1 = Faces.Ten;
                    break;
                case ("J"):
                    face1 = Faces.Jack;
                    break;
                case ("Q"):
                    face1 = Faces.Queen;
                    break;
                case ("K"):
                    face1 = Faces.King;
                    break;
                case ("A"):
                    face1 = Faces.Ace;
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }

            Suits suit1;

            switch (suit)
            {
                case "S":
                    suit1 = Suits.Spades;
                    break;
                case "H":
                    suit1 = Suits.Hearts;
                    break;
                case "D":
                    suit1 = Suits.Diamonds;
                    break;
                case "C":
                    suit1 = Suits.Clubs;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return new Card(face1, suit1);
        }
    }
    class Card
    {
        public Card(Faces face, Suits suit)
        {
            Face = face;
            Suit = suit;
        }

        public Faces Face { get; private set; }
        public Suits Suit { get; private set; }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append('[');
            if ((int)Face == 11)
            {
                sb.Append("J");
            }
            else if ((int)Face == 12)
            {
                sb.Append("Q");
            }
            else if ((int)Face == 13)
            {
                sb.Append("K");
            }
            else if ((int)Face == 14)
            {
                sb.Append("A");
            }
            else
            {
                sb.Append((int)Face);
            }
            switch (Suit)
            {
                case Suits.Spades:
                    sb.Append('\u2660');
                    break;
                case Suits.Hearts:
                    sb.Append('\u2665');
                    break;
                case Suits.Diamonds:
                    sb.Append('\u2666');
                    break;
                case Suits.Clubs:
                    sb.Append('\u2663');
                    break;
                default:
                    break;
            }
            sb.Append(']');


            return sb.ToString().Trim();
        }

    }
    public enum Faces { Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14 }
    public enum Suits { Spades, Hearts, Diamonds, Clubs }
}
