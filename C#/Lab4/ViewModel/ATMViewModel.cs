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
        public Card LastLoginCard { get; private set; }
        public string LastLogin { get; private set; }
        //

        public ATMViewModel()
        {
            AllCards = DataBaseWorker.getCardsFromDataBase(DataBaseWorker.CardPath);
            MoneyInATM = DataBaseWorker.getMoneyInATM(DataBaseWorker.AtmInfoPath);
            DataBaseWorker.blockCards(this.AllCards, DataBaseWorker.BlockedCardPath);
            this.AttemptsToSingIn = 3;
            LastLogin = String.Empty;
        }
        public LoginContinions singInWithAttempts(string login, string password)
        {
            if (!login.Equals(LastLogin))
            {
                AttemptsToSingIn = maxAttempstToSingIn;
                LastLoginCard = findCard(login);
                LastLogin = login;
            }
            if (LastLoginCard.Blocked) return LoginContinions.BLOCKED;
            if (AttemptsToSingIn == 0) { 
                LastLoginCard.Blocked = true;
                DataBaseWorker.saveBlockedCard(LastLoginCard,DataBaseWorker.BlockedCardPath);
            }
            if (LastLoginCard.Blocked) return LoginContinions.BLOCKED;
            if (LastLoginCard == null) return LoginContinions.DOESNTEXIST;
            if (LastLoginCard.Password.Equals(password))
            {
                AttemptsToSingIn = maxAttempstToSingIn;
                CurrentCard = LastLoginCard;
                LastLoginCard = null;
                return LoginContinions.SUCCESS;
            }
            else {
                AttemptsToSingIn--;
                return LoginContinions.PASSWORDERROR;
            }
        }
        public bool singIn(string login, string password) {
            Card potentialCard = findCard(login);
            if (potentialCard != null && potentialCard.Password.Equals(password))
            {
                CurrentCard = potentialCard;
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
        public bool haveMoneyInAtm(int howMuch) { return MoneyInATM >= howMuch; }
        public bool getMoney(int howMuch) {
            if (CurrentCard.MoneyRubels < howMuch || MoneyInATM<howMuch) return false;
            CurrentCard.MoneyRubels -= howMuch;
            MoneyInATM -= howMuch;
            DataBaseWorker.saveMoneyInATM(MoneyInATM,DataBaseWorker.AtmInfoPath);
            DataBaseWorker.saveCards(AllCards, DataBaseWorker.CardPath);
            return true;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        ~ATMViewModel() {
            DataBaseWorker.saveCards(AllCards,DataBaseWorker.CardPath);
            DataBaseWorker.saveMoneyInATM(MoneyInATM,DataBaseWorker.AtmInfoPath);
        }
    }
}
