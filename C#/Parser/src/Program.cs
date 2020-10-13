using System;
using System.IO;
using System.Collections.Generic;
namespace Parser
{
    class Program
    {//I:\\Practice\\C#\\Parser\\data\\Text.txt      /home/kirill/Practice/C#/Parser/data/Text.txt
        static void Main(string[] args)
        {
            Text txt=new Text(ReadFile("I:\\Practice\\C#\\Parser\\data\\Text.txt"));
            showBySentens(txt);
        }
        public static void showBySentens(Text txt){
            foreach(Sentens sen in txt.Sentenses){
                foreach(Word word in sen.Words){
                    Console.Write(word.Value+' ');
                }
                Console.WriteLine("\n|||||||||||||||||||||||||||||");
            }
        } 
        public static string[] showBySentensLength(Text txt){
            Sentens [] sentenses=txt.Sentenses;
            string[] res=new string[sentenses.Length];
            for(int i=0;i<sentenses.Length;i++){
                
            }
        }
        public static string ReadFile(string path){
            try{
                StreamReader file=new StreamReader(path);
                return file.ReadToEnd();
            }catch(Exception e){
                return null;
            }
        }
    }
}
