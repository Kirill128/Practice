using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.IO;
using System.Text.RegularExpressions;

namespace Cards
{
    public class Card
    {
        public string Num { private set; get; }
        public bool IsLegal { private set; get; }
        public string FirmName { private set; get; }
        public string FirmRule { private set; get; }

        public Card(string num)
        {
            this.Num = num;
            this.IsLegal = checkLegit(num);
            LinkedList<string[]> firms = getFirms("I:\\Practice\\C#\\Cards\\firmsdata\\firmsrules.txt");
            LinkedListNode<string[]> firm = firms.First;
            do{
                if (Regex.IsMatch(firm.Value[0], firm.Value[1])) {
                    this.FirmName = firm.Value[0];
                    this.FirmRule = firm.Value[1];
                    break;
                }
                firm = firm.Next;
            }while (firm!=firms.Last) ;
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
    }
}