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
                Console.WriteLine("@ " + w.Value);
            }

            //task3              B, C, D, F, G, H, J, K, L, M, N, P, Q, R, S, T, V, W, X, Z
            Console.WriteLine("\nTask 3\nInput length of word:");
            removeWordsByLetters(txt,getWordLength(),new Letter[] {new Letter('z'), new Letter('b'), new Letter('c'), new Letter('d'),
            new Letter('f'),new Letter('g'),new Letter('h'),new Letter('j'),new Letter('k'),new Letter('l'),new Letter('m'), new Letter('n'),
            new Letter('p'), new Letter('q'),new Letter('r'),new Letter('s'),new Letter('t'),new Letter('v'),new Letter('w'),new Letter('x')});
            foreach (Sentens s in task1)
            {
                Console.WriteLine(s.Value);
            }
            //task 4
            
            
        }
        public static void removeWordsByLetters(Text text,int length,Letter [] checkLetters){//Сгорело из-за реализации листов. 
            //при foreach и IEnumarator нельзя менять коллекцию(даже удалять)!!
            IEnumerator ieS,ieP;//HELP, за что ты так со мной, шарп
            Symbol firstSymbol;
            
            
            foreach(Sentens sentens in text.Sentenses){
                List<Word> newWords = new List<Word>();
                List<PunctuationSymbol> punctuation = new List<PunctuationSymbol>();
                ieP = sentens.PunctuationSymbols.GetEnumerator();
                int wordCounter=0;
                foreach (Word wordIter in sentens.Words) {
                    wordCounter++;
                    bool correct = true; 
                    ieS = wordIter.Symbols.GetEnumerator();
                    ieP.MoveNext();
                    ieS.MoveNext();
                    firstSymbol=(Symbol)ieS.Current;
                    if (Letter.isLetter(firstSymbol)){
                        foreach (Letter l in checkLetters) {
                            if (l.Value == Letter.toLower(firstSymbol.Value)) {
                                correct = false;
                                break;
                            }
                        }
                        if (wordIter.Symbols.Count != length || correct) {
                            newWords.Add(wordIter);
                            
                            foreach(PunctuationSymbol p in sentens.PunctuationSymbols){
                                if(p.PositionByWord>wordCounter)p.PositionByWord--;
                            }
                        }
                    }

                }
                
                sentens.Words = newWords;
                sentens.PunctuationSymbols = punctuation;
            }
            
       }
/*       
        public static void removeWBL(Text text, int length, Letter[] checkLetters) {
            LinkedList<Sentens> sentenses = new LinkedList<Sentens>(text.Sentenses);
            for (LinkedListNode<Sentens> sentens=sentenses.First;sentens.Next!=null;sentens=sentens.Next ) {
                LinkedList<Word> words = new LinkedList<Word>(sentens.Words);
                LinkedList<PunctuationSymbol> punctSymbols = new LinkedList<Word>(sentens.PunctuationSymbols);

                LinkedListNode<PunctuationSymbol> punctSymbol =punctSymbols.First;
                LinkedListNode<Word> word =words.First;
                for(;word.Next!=null;word=word.Next){
                    IEnumerator ieS=word.Value.Symbols.GetEnumerator();
                    ieS.MoveNext();
                    bool isSameLetter=false;
                    for(int i=0;i<checkLetters.Length;i++){
                        if(checkLetters[i].Value==((Symbol)ieS.Current).Value){
                            isCorrectLetter=true;
                            break;
                        }
                    }
                    if(word.Value.Symbols.Count==length && isCorrectLetter){
                        sentens.Remove(word);

                    }
                }

            }
            text.Sentenses=new List<Sentens>(sentenses);

        }
        public stataic LinkedList<T> addFromListToLinked<T> (List<T> list){
            return null;
        }
        public stataic List<T> addFromListToLinked<T>(LinkedList<T> linked){
            return null;
        }
        
        */
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
        //побыстрее бы ...
    }
}
