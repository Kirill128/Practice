using System;
using System.IO;
using System.Collections.Generic;
namespace Parser
{
    class Program
    {//I:\\Practice\\C#\\Parser\\data\\Text.txt      /home/kirill/Practice/C#/Parser/data/Text.txt
        static void Main(string[] args)
        {
            Text txt=new Text(ReadFile("/home/kirill/Practice/C#/Parser/data/Text.txt"));
            showByWords(txt);
	    Sentens[]sen=sortBySentensLength(txt);
	    foreach(Sentens s in sen){
	    	Console.WriteLine(s.Value);
		Console.WriteLine(s.Words.Length);
	    }
        }
        public static void showByWords(Text txt){
            foreach(Sentens sen in txt.Sentenses){
                foreach(Word word in sen.Words){
                    Console.Write(word.Value+' ');
                }
                Console.WriteLine("\n|||||||||||||||||||||||||||||");
            }
        }
        public static LinkedList<Word> getWordFromQuestionSentens(Text txt){
		LinkedList<Word> res=new LinkedList<Word>();
		return res;	
	}	
        public static Sentens[] sortBySentensLength(Text txt){
            Sentens [] sentenses=new Sentens[txt.Sentenses.Length];
            for(int i=0;i<sentenses.Length;i++){
                sentenses[i] =new Sentens(txt.Sentenses[i].Value);
            }
	    for(int i=0;i<sentenses.Length;i++){
	    	for(int j=i+1;j<sentenses.Length;j++){
			if(sentenses[i].Words.Length<sentenses[j].Words.Length)
			{
				Sentens sen=sentenses[i];
				sentenses[i]=sentenses[j];
				sentenses[j]=sen;
			}
		}
	    }
	    return sentenses;
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
