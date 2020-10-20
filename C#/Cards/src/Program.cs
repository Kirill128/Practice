using System;
using System.Collections.Generic;

namespace Cards
{
    class Program
    {
        static void Main(string[] args) {
            LinkedList<Card> cards = inputCards();
            foreach (Card c in cards) {
                Console.WriteLine(c.FirmName + c.Num + "\n");
            }
        }
        public static LinkedList<Card> inputCards()
        {
            LinkedList<Card> allcards = new LinkedList<Card>();
            bool work = true;

            while (work) {
                Console.WriteLine("Input num:");
                Card card = new Card(Console.ReadLine());
                if (card.IsLegal) allcards.AddLast(card);
                Console.WriteLine("Exit ?");
                if (Console.ReadLine() == "yes") work = false;
            }
            return allcards;
        }
    }
}
