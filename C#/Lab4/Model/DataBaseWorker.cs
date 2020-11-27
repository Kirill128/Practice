using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Lab4.Model
{
    public class DataBaseWorker
    {
        public const string CardPath= "C:\\Users\\Laptop\\source\\repos\\Practice\\C#\\Lab4\\database\\cards.txt";

        public const string BlockedCardPath = "C:\\Users\\Laptop\\source\\repos\\Practice\\C#\\Lab4\\database\\blockedcards.txt";

        public const string AtmInfoPath = "C:\\Users\\Laptop\\source\\repos\\Practice\\C#\\Lab4\\database\\atminfo.txt";

        public DataBaseWorker() {
            
        }
        public static void saveCards(ObservableCollection<Card> cards,string filePath) {
            try {
                using (StreamWriter file = new StreamWriter(filePath)) {
                    foreach (Card c in cards) {
                        file.WriteLine(c.Num+"/"+c.Password+"//"+c.MoneyRubels);
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message) ;
            }
                
        }
        public static void saveBlockedCard(Card blockedCard,string filePath) {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath,true))
                {
                        file.WriteLine(blockedCard.Num);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void saveMoneyInATM(int money ,string filePath) {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    file.WriteLine(money);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public  static void blockCards(ObservableCollection<Card> cards, string filePath)
        {
            try
            {
                StreamReader file = new StreamReader(filePath);
                string card;
                while ((card = file.ReadLine()) != null)
                {
                    foreach (Card c in cards)
                    {
                        if (c.Num.Equals(card)) c.Blocked = true;
                    }
                }

            }
            catch (IOException e)
            {
                throw e;
            }

        }
        public static LinkedList<Card> getBlockedCards(string path)
        {
            LinkedList<Card> cards = new LinkedList<Card>();
            try
            {
                StreamReader file = new StreamReader(path);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return cards;
        }
        public static int getMoneyInATM(string filePath)
        {
            int result = 0;
            try
            {
                StreamReader file = new StreamReader(filePath);
                result = Convert.ToInt32(file.ReadLine());
            }
            catch (IOException e)
            {
                throw e;
            }
            return result;
        }
        public static ObservableCollection<Card> getCardsFromDataBase(string path)
        {
            ObservableCollection<Card> cards = new ObservableCollection<Card>();
            try
            {
                StreamReader file = new StreamReader(path);
                string card;
                while ((card = file.ReadLine()) != null)
                {
                    string[] cardInfo = card.Split(new char[] { '/' });
                    cards.Add(new Card(cardInfo[0], cardInfo[1], Convert.ToInt32(cardInfo[2])));
                }

            }
            catch (IOException e)
            {
                throw e;
            }
            return cards;
        }
    }
}
