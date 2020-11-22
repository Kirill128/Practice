using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cards.src
{
    class ATM
    {
        private string CardsPath;

        private string MoneyPath;
        
        private string BlockedCardsPath;

        private LinkedList<Card> Cards { get;  set; }
        public int MoneyInATM { private set; get; }

        public ATM(string cardsPath,string moneyPath,string blockedCardsPath) {
            this.CardsPath = cardsPath;
            this.MoneyPath = moneyPath;
            this.BlockedCardsPath = blockedCardsPath;
            Cards = getCardsFromDataBase(this.CardsPath);
            MoneyInATM = getMoneyInATM(this.MoneyPath);
            blockCards(this.Cards,this.BlockedCardsPath);
        }

        private static void blockCards(LinkedList<Card> cards,string filePath) {
            try
            {
                StreamReader file = new StreamReader(filePath);
                string card;
                while ((card = file.ReadLine()) != null)
                {
                    foreach (Card c in cards) {
                        if (c.Num.Equals(card)) c.Blocked = true;
                    }
                }

            }
            catch (IOException e)
            {
                throw e;
            }
           
        }
        private static int getMoneyInATM(string filePath) {
            int result = 0;
            try
            {
                StreamReader file = new StreamReader(filePath);
                result = Convert.ToInt32(file.ReadLine());
            }
            catch (IOException e) {
                throw e;
            }
            return result;
        }
        private static LinkedList<Card> getCardsFromDataBase(string path) {
            LinkedList<Card> cards = new LinkedList<Card>();
            try {
                StreamReader file = new StreamReader(path);
                string card;
                while ((card=file.ReadLine())!=null) {
                    string[] cardInfo = card.Split(new char[] {'/'});
                    cards.AddLast(new Card(cardInfo[0],cardInfo[1],Convert.ToInt32(cardInfo[2])));
                }
                
            }
            catch(IOException e) {
                throw e;
            }
            return cards;
        }

    }
}
