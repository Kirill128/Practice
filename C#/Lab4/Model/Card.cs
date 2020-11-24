using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab4.Model
{
    public class Card: INotifyPropertyChanged
    {
        public bool blocked;
        public int moneyRubels; 
        public string Num { private set; get; }
        public string Password { private set; get; }
        public bool Blocked { 
            set {
                blocked = value;
                OnPropertyChanged("Blocked");
            }
            get { return blocked; } }
        public int MoneyRubels {
            set
            {
                if (value >= 0)
                {
                    moneyRubels = value;
                    OnPropertyChanged("MoneyRubels");
                }
            }
            get { return moneyRubels; }
        }
        public bool IsLegal { private set; get; }
        public string FirmName { private set; get; }
        public string FirmRule { private set; get; }

        private static LinkedList<string[]>  firmsData;

        private static LinkedList<string[]> FirmsData {
            set{ firmsData = value; }
            get{  return firmsData; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Card(string num,string passw,int moneyrubels)
        {
            if(FirmsData==null)FirmsData = getFirms("/home/kirill/Practice/C#/Cards/firmsdata/firmsrules.txt");
            this.Num = num;
            this.Password = passw;
            this.MoneyRubels = moneyrubels;
            this.IsLegal = checkLegit(num);
            LinkedListNode<string[]> firm = FirmsData.First;
            while(firm!=null){
                Console.WriteLine("Reg:"+firm.Value[1]+"  "+Regex.IsMatch(this.Num, @firm.Value[1]));
                if (Regex.IsMatch(this.Num, @firm.Value[1])) {
                    this.FirmName = firm.Value[0];
                    this.FirmRule = firm.Value[1];
                    break;
                }
                firm = firm.Next;
            }
        }
        public static LinkedList<string[]> getFirms(string path)
        {
            LinkedList<string[]> res = new LinkedList<string[]>();
            try
            {
                StreamReader file = new StreamReader(path);
                string name, rule;
                while ((name = file.ReadLine()) != null && (rule = file.ReadLine()) != null)
                {
                    res.AddLast(new string[] { name, rule });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return res;

        }
        public static bool checkLegit(string num)
        {
            int sum = 0;
            for (int i = 0; i < num.Length; i += 2)
                sum += (int)num[i] - 48;
            for (int i = 1, buf; i < num.Length; i += 2)
            {
                buf = ((int)num[i] - 48) * 2;
                if (buf > 9)
                    sum++;
                sum += buf % 10;
            }
            return sum % 10 == 0;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}