using System;
using System.IO;
namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Text txt=new Text(ReadFile("/home/kirill/Practice/C#/Parser/data/Text.txt"));
            showBySentens(txt);
        }
        public static void showBySentens(Text txt){
            foreach(Sentens sen in txt.Sentenses){
                foreach(Word word in sen.Words){
                    Console.WriteLine();
                }
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
