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
    {   // Data for work with Card
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
        public int MoneyInATM { private set; get; }

        //Data for Authorization
        public const int maxAttempstToSingIn = 3;

        private int attemtsToSingIn;
        public int AttemptsToSingIn {
            get { return attemtsToSingIn; }
            private set {
                if (value > -1 && value <= maxAttempstToSingIn)
                    attemtsToSingIn = value;
                else
                    attemtsToSingIn = maxAttempstToSingIn;
            }
        }

        public string LastLogin { get; private set; }

        public Card LastLoginCard { get; private set; }
        //

        public ATMViewModel(string cardsPath, string moneyPath, string blockedCardsPath)
        {
            AllCards = DataBaseWorker.getCardsFromDataBase(cardsPath);
            MoneyInATM = DataBaseWorker.getMoneyInATM(moneyPath);
            DataBaseWorker.blockCards(this.AllCards, blockedCardsPath);
            this.AttemptsToSingIn = 3;
        }

        public LoginContinions singInWithAttempts(string login, string password)
        {
            if (AttemptsToSingIn != 0)
            {
                if (singIn(login, password))
                {
                    AttemptsToSingIn = maxAttempstToSingIn;
                    LastLogin = String.Empty;
                    LastLoginCard = null;
                    return LoginContinions.SUCCESS;
                }
                else
                {
                    if (LastLogin.Equals(login))
                    {

                        return LoginContinions.PASSWORDERROR;
                    }
                    else
                    {
                        LastLogin = login;
                        AttemptsToSingIn = maxAttempstToSingIn;
                        return LoginContinions.NEW;
                    }
                }
            }
            else
            {

                return LoginContinions.BLOCKED;
            }
        }

        public bool singIn(string login, string password) {
            Card potentialCard = findCard(login);
            if (potentialCard!=null && potentialCard.Password.Equals(password))
            {
                return true;
            }
            return false;
        }

        private Card findCard(string num) {
            foreach (Card c in AllCards)
            {
                if (c.Num.Equals(num))
                    return c;
            }
            return null;
        }
        public bool getMoney(int howMuch) {
            if (CurrentCard.MoneyRubels < howMuch) return false;
            CurrentCard.MoneyRubels -= howMuch;
            return true;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
