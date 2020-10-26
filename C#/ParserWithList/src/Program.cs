using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ParserWithList {
    class Program
    { //"I:\\Practice\\C#\\ParserWithList\\data\\Text.txt"     /home/kirill/practice/c#/parser/data/text.txt
        static void Main (string[] args) {
            Text txt = new Text(ReadFile("I:\\Practice\\C#\\ParserWithList\\data\\Text.txt"));
            foreach (Sentens s in txt.Sentenses)
            {
                Console.WriteLine(s.Value);          
            }
            Console.WriteLine();
            
            //task 1
            List<Sentens> task1 = getSortedBySentensLength(txt);
            foreach (Sentens s in task1) {
                Console.WriteLine(s.Value);
            }
            //task 2
        }
        public static List<Sentens> getSortedBySentensLength(Text txt)
        {
            List<Sentens> sentenses = new List<Sentens>();
            IEnumerator ie1 = txt.Sentenses.GetEnumerator(), ie2=txt.Sentenses.GetEnumerator();
            Sentens bufSen1,bufSen2,minSen;

            while (ie1.MoveNext()) {
                ie2.MoveNext();
                bufSen1 = (Sentens)ie1.Current;
                minSen = bufSen1;
                while (ie2.Current != ie1.Current) ie2.MoveNext();

                while (ie2.MoveNext()) {
                    bufSen2 = (Sentens)ie2.Current;
                    if (bufSen2.Words.Count < minSen.Words.Count)
                        minSen = bufSen2;
                }
                sentenses.Add(new Sentens(minSen.Words, minSen.PunctuationSymbols));
                ie2.Reset();
            }

            return sentenses;
        }
        public static string ReadFile(string path)
        {
            try
            {
                StreamReader file = new StreamReader(path);
                return file.ReadToEnd();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
