using System;
using System.Collections.Generic;

namespace Cards
{
    class Program
    {
        static void Main(string[] args) {
            List<Card> cards = inputCards();
            foreach (Card c in cards) {
                Console.WriteLine(c.FirmName + c.Num + "\n");
            }
        }
        public static List<Card> inputCards()
        {
            List<Card> allcards = new List<Card>();
            bool work = true;

            while (work) {
                Console.WriteLine("Input num:");
                Card card = new Card(Console.ReadLine());
                if (card.IsLegal) allcards.Add(card);
                Console.WriteLine("Legal:{0}\nFirmName:{1}\nExit ?",card.IsLegal,card.FirmName);
                if (Console.ReadLine() == "yes") work = false;
            }
            return allcards;
        }
    }
}
