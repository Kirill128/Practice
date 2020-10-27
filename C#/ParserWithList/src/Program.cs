using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ParserWithList {
    class Program
    { //"I:\\Practice\\C#\\ParserWithList\\data\\Text.txt"     /home/kirill/practice/c#/parser/data/text.txt
        static void Main (string[] args) {
            Text txt = new Text(ReadFile("/home/kirill/Practice/C#/ParserWithList/data/Text.txt"));
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
            Sentens[] sen = txt.Sentenses.ToArray();
            for(int i=0;i<sen.Length;i++){
                for(int j=i;j<sen.Length;j++){
                    if(sen[i].Words.Count>sen[j].Words.Count){
                        Sentens buf=sen[i];
                        sen[i]=sen[j];
                        sen[j]=buf;
                    }
                }
            }
            return new List<Sentens>(sen);
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
