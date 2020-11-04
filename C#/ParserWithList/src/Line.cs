using System;
using System.Collections.Generic;
using System.Text;

namespace ParserWithList.src
{
	class Line
	{
		public LinkedList<Word> Words { get; set; }
		public LinkedList<PunctuationSymbol> PunctuationSymbols { get; set; }

		public Line(string txt) {
			PunctuationSymbols = new LinkedList<PunctuationSymbol>();
			Words = new LinkedList<Word>();
			StringBuilder word = new StringBuilder("");
			for (int i = 0; i < txt.Length; i++)
			{
				if (PunctuationSymbol.IsPunctuationSymbol(txt[i]) || txt[i] == '/')
				{
					if (word.Length != 0) Words.AddLast(new Word(word.ToString()));
					PunctuationSymbols.AddLast(new PunctuationSymbol(txt[i], Words.Count));
					word.Remove(0, word.Length);
				}
				else
				{
					word.Append(txt[i]);
				}
			}
			LinkedList<PunctuationSymbol> punctSymb = new LinkedList<PunctuationSymbol>();
			foreach (PunctuationSymbol p in PunctuationSymbols)
			{
				if (p.Value != '\0')
					punctSymb.AddLast(p);
			}
			PunctuationSymbols = punctSymb;
		}
		public static void sortWordsByAlphabet(LinkedList<Word> words) {
			
			for (LinkedListNode<Word> firstIter = words.First;firstIter.Next!=null;firstIter=firstIter.Next) {
				for (LinkedListNode<Word> secondIter = firstIter; secondIter.Next != null; secondIter = secondIter.Next) {
					if (firstIter) {
						LinkedListNode<Word> buf = firstIter;
						firstIter.Value = secondIter.Value;
						secondIter.Value = buf.Value;
					}
				}
			}
		}
	}
}
