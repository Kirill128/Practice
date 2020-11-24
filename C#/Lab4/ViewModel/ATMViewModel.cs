using Lab4.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab4.ViewModel
{
    public class ATMViewModel : INotifyPropertyChanged
    {
        private Card currentCard;
        public Card CurrentCard { get {
                return currentCard;
            }
            set {
                currentCard = value;
                OnPropertyChanged("CurrentCard");
            }
        }
        public ObservableCollection<Card> AllCards { get; set; }
      
        private string CardsPath;

        private string MoneyPath;

        private string BlockedCardsPath;
        public int MoneyInATM { private set; get; }

        public ATMViewModel(string cardsPath, string moneyPath, string blockedCardsPath)
        {
            this.CardsPath = cardsPath;
            this.MoneyPath = moneyPath;
            this.BlockedCardsPath = blockedCardsPath;
            AllCards = getCardsFromDataBase(this.CardsPath);
            MoneyInATM = getMoneyInATM(this.MoneyPath);
            blockCards(this.AllCards, this.BlockedCardsPath);
        }

        public bool singIn(string login,string password) {
            foreach (Card c in AllCards)
            {
                if (c.Num.Equals(login) && c.Password.Equals(password))
                {
                    CurrentCard = c;
                    return true;
                }
            }
            return false;
        }
        public bool getMoney(int howMuch) {
            if (CurrentCard.MoneyRubels < howMuch) return false;
            CurrentCard.MoneyRubels -= howMuch;
            return true;
        }
        private static void blockCards(ObservableCollection<Card> cards, string filePath)
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

            }
            return cards;
        }
        private static int getMoneyInATM(string filePath)
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
        private static ObservableCollection<Card> getCardsFromDataBase(string path)
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
