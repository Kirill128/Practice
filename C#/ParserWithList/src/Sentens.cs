
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ParserWithList
{
	class Sentens{
        public List<Word> Words{get;set;}
		public List<PunctuationSymbol> PunctuationSymbols{get;set;}
		

		public string Value{
			get {
				StringBuilder val = new StringBuilder(40);
				IEnumerator ieW = Words.GetEnumerator();
				IEnumerator ieP = PunctuationSymbols.GetEnumerator();
				for (bool playW = ieW.MoveNext(), playP = ieP.MoveNext(); playW || playP; playW = ieW.MoveNext(), playP = ieP.MoveNext()) {
					if (playW) val.Append(((Word)ieW.Current).Value);
					if (playP)
					{
						PunctuationSymbol p = (PunctuationSymbol)ieP.Current;
						//if (PunctuationSymbol.IsPunctuationSymbol(p)) {
							val.Append(p.Value );
						//	if (ieP.MoveNext()) val.Append(((PunctuationSymbol)ieP.Current).Value);
						//}
					//	else val.Append(p.Value);
					}
				}
				return val.ToString();
			}
		}

		public Sentens(string txt) {
			PunctuationSymbols = new List<PunctuationSymbol>();
			Words = new List<Word>();
			StringBuilder word = new StringBuilder("");
			for (int i = 0; i < txt.Length; i++)
			{
				if (PunctuationSymbol.IsPunctuationSymbol(txt[i]) || txt[i] == '/')
				{
					PunctuationSymbols.Add(new PunctuationSymbol(txt[i]));
					if (word.Length != 0) Words.Add(new Word(word.ToString()));
					word.Remove(0, word.Length);
				}
				else
				{
					word.Append(txt[i]);
				}
			}

		}
		public Sentens(List<Word> words,List<PunctuationSymbol> punct) {
			PunctuationSymbols = new List<PunctuationSymbol>();
			Words = new List<Word>();
			foreach (Word w in words) {
				Words.Add(new Word(w.Value));
			}
			foreach (PunctuationSymbol p in punct) {
				PunctuationSymbols.Add(new PunctuationSymbol(p.Value));
			}
		}
		 
	}
}
