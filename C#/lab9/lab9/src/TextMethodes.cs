using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace lab9.src
{
    class TextMethodes
    {
        public static bool ExistWordInString(string str,string word) {
            return str.Contains(word);
        }
        public static LinkedList<string> FindByPattern(string allText,string pattern) {
            LinkedList<string> res=new LinkedList<string>();
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(allText);
            foreach (Match match in matches) {
                res.AddLast(match.Value);
            }
            return res;
        }
        public static string DeleteWordsByPattern(string txt,string pattern ) {
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            return rg.Replace(txt,"");
        }
        public static string ReplaceByPattern(string txt ,string pattern ,string to) {
            Regex rg = new Regex(pattern, RegexOptions.IgnoreCase);
            return rg.Replace(txt,to);
        }
        public static LinkedList<WordBox> GetUniqueWordBoxes(LinkedList<string> allstr) {
            int lineCount = 0;
            LinkedList<WordBox> wordBoxes = new LinkedList<WordBox>();
            foreach (string line in allstr) {
                lineCount++;
                string[] words = line.Split(new char[] {' ',',', ':', '!', '?', '-', '.', '\\', '_' });
                for (int i=0;i<words.Length;i++) {
                    bool existInWordBox = false;                
                    foreach (WordBox wordBox in wordBoxes) {
                        if (words[i].Equals(wordBox.Word)) {
                            existInWordBox = true;
                            wordBox.Count++;

                            bool theSameLine = false;
                            foreach (int meet in wordBox.MeetInLines) {
                                if (meet == lineCount)
                                {
                                    theSameLine = true;
                                    break;
                                }
                            }
                            if (!theSameLine)
                                wordBox.MeetInLines.AddLast(lineCount);
                            break;
                        }         
                    }
                    if (!existInWordBox) {
                        wordBoxes.AddLast(new WordBox(words[i],lineCount));
                    }
                }
            }
            return wordBoxes;
        }
        public static LinkedList<WordBox> sortWordsByAlphabet(LinkedList<WordBox> words)
        {

            for (LinkedListNode<WordBox> firstIter = words.First; firstIter.Next != null; firstIter = firstIter.Next)
            {
                for (LinkedListNode<WordBox> secondIter = firstIter; secondIter.Next != null; secondIter = secondIter.Next)
                {
                    if (String.Compare(firstIter.Value.Word, secondIter.Value.Word) > 0)
                    {
                        WordBox buf = firstIter.Value;
                        firstIter.Value = secondIter.Value;
                        secondIter.Value = buf;
                    }
                }
            }
            return words;
        }
    }
}
