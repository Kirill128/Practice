using System;
using System.Text;
using System.Collections.Generic;
namespace Parser{
	class Sentens{
        public Word [] Words{get;set;}

	
		public List<PunctuationSymbol> PunctuationSymbols{get;set;}
        public string Value{get;set;} 
		
		public Sentens(string txt){
           	
			List<PunctuationSymbol> punctuationSymbols=new List<PunctuationSymbol>();
			List<Word> words=new List<Word>();
			StringBuilder word = new StringBuilder("");
			for(int i=0;i<txt.Length;i++){
				if(PunctuationSymbol.IsPunctuationSymbol(txt[i]) || txt[i]==' '){
					punctuationSymbols.Add(new PunctuationSymbol(txt[i]));
					if(word.Length!=0)words.Add(new Word(word.ToString()));
					word.Remove(0,word.Length);
				}else{
					word.Append(txt[i]);
				}
			}
			PunctuationSymbols=punctuationSymbols;
			Words=words.ToArray();

			StringBuilder val=new StringBuilder();
			foreach(Word w in Words){
				val.Append(w.Value+);
			}

		}
	}
}
