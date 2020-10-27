using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ParserWithList
{
    class Program
    { //"I:\\Practice\\C#\\ParserWithList\\data\\Text.txt"     /home/kirill/practice/c#/parser/data/text.txt
        static void Main(string[] args)
        {
            Text txt = new Text(ReadFile("/home/kirill/Practice/C#/ParserWithList/data/Text.txt"));
            foreach (Sentens s in txt.Sentenses)
            {
                Console.WriteLine(s.Value);
            }
            Console.WriteLine();

            //task 1
            Sentens[] task1 = getSortedBySentensLength(txt);
            foreach (Sentens s in task1)
            {
                Console.WriteLine(s.Value);
            }
            //task 2
            Console.WriteLine("\nTask 2\nInput length of word:");
            int wordlength = getWordLength();
            List<Word> words = getWordsFromQuestionSentenses(txt, wordlength);
            foreach (Word w in words)
            {
                Console.WriteLine("@" + w.Value);
            }

            //task3

        }
        public static void removeWordsByLetters(Text text,int length,Letter [] checkLetters){
            IEnumerator ie;
            Letter currentLetter;
            foreach(Sentens sentens in text.Sentenses){
                foreach(Word word in sentens.Words){
                    ie=word.Symbols.GetEnumarator();
                    firstLetter=(Letter)ie.Current;
                    if(ie.MoveNext() && Letter.isLetter( firstL){
                        for(){

                        }
                    }
                }
            }
        }
        public static Sentens[] getSortedBySentensLength(Text txt)
        {
            Sentens[] sen = txt.Sentenses.ToArray();
            for (int i = 0; i < sen.Length; i++)
            {
                for (int j = i; j < sen.Length; j++)
                {
                    if (sen[i].Words.Count > sen[j].Words.Count)
                    {
                        Sentens buf = sen[i];
                        sen[i] = sen[j];
                        sen[j] = buf;
                    }
                }
            }
            return sen;
        }
        public static List<Word> getWordsFromQuestionSentenses(Text txt, int length)
        {
            List<Word> resList = new List<Word>();
            bool isQuestionSen;
            foreach (Sentens sentens in txt.Sentenses)
            {
                //check punctSymbol   
                isQuestionSen = false;
                foreach (PunctuationSymbol p in sentens.PunctuationSymbols)
                {
                    if (p.Value == '?')
                    {
                        isQuestionSen = true;
                        break;
                    }
                }
                //checkWords
                if (isQuestionSen)
                {
                    foreach (Word word in sentens.Words)
                    {
                        //checkLengthWord
                        string wordVal = word.Value;
                        if (wordVal.Length == length)
                        {
                            //checkContain this word in res
                            bool contains = false;
                            foreach (Word w in resList)
                            {
                                if (wordVal == w.Value)
                                {
                                    contains = true;
                                    break;
                                }
                            }

                            //add if all ok
                            if (!contains) resList.Add(word);
                        }
                    }

                }
                //

            }
            return resList;

        }
        public static int getWordLength()
        {
            int wordlength = 0;
            try
            {
                wordlength = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return wordlength;
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
