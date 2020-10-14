using System;
using System.Collections.Generic;
using System.IO;
namespace Parser {
    class Program { //I:\\Practice\\C#\\Parser\\data\\Text.txt      /home/kirill/Practice/C#/Parser/data/Text.txt
        static void Main (string[] args) {
            Text txt = new Text (ReadFile("I:\\Practice\\C#\\Parser\\data\\Text.txt"));
            showByWords (txt);
            //task1
            Sentens[] sen = sortBySentensLength (txt);
            foreach (Sentens s in sen) {
                Console.WriteLine (s.Value);
                Console.WriteLine (s.Words.Length);
            }
            //task2
            Console.WriteLine("Input length of word:");
            try{
                int wordlength=Convert.ToInt32(Console.ReadLine());
                List<Word> words=getWordFromQuestionSentens(wordlength,txt);
                foreach(Word w in words){
                    Console.WriteLine(w.Value);
                }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }

        }
        public static void showByWords (Text txt) {
            foreach (Sentens sen in txt.Sentenses) {
                foreach (Word word in sen.Words) {
                    Console.Write (word.Value + ' ');
                }
                Console.WriteLine ("\n|||||||||||||||||||||||||||||");
            }
        }
        public static List<Word> getWordFromQuestionSentens (int length,Text txt) {
            List<Word> res = new List<Word> ();
            Sentens[] sentenses =txt.Sentenses;
            bool isQuestion;
            for(int senCount=0;senCount<sentenses.Length;senCount++){
                isQuestion=false;
                foreach(PunctuationSymbol p in sentenses[senCount].PunctuationSymbols){
                    if(p.Value=='?')isQuestion=true;
                }
                if(isQuestion){
                    foreach(Word w in sentenses[senCount].Words){
                        if(length==w.Value.Length){
                            foreach(Word wor in res){
                                if(wor.Value!=w.Value)res.Add(w);
                            }
                        }
                    }
                }
            }
            return res;
        }
        public static Sentens[] sortBySentensLength (Text txt) {
            Sentens[] sentenses = new Sentens[txt.Sentenses.Length];
            for (int i = 0; i < sentenses.Length; i++) {
                sentenses[i] = new Sentens (txt.Sentenses[i].Value);
            }
            for (int i = 0; i < sentenses.Length; i++) {
                for (int j = i + 1; j < sentenses.Length; j++) {
                    if (sentenses[i].Words.Length < sentenses[j].Words.Length) {
                        Sentens sen = sentenses[i];
                        sentenses[i] = sentenses[j];
                        sentenses[j] = sen;
                    }
                }
            }
            return sentenses;
        }
        public static string ReadFile (string path) {
            try {
                StreamReader file = new StreamReader (path);
                return file.ReadToEnd ();
            } catch (Exception e) {
                return null;
            }
        }
    }
}