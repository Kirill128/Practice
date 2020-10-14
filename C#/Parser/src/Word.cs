namespace Parser{
	class Word{
                public Symbol[] Symbols{get;set;}
                public string Value{get;set;}
                public Word(string txt){
                this.Value=txt;
                char[] symbarr=txt.ToCharArray();
                Symbols=new Symbol[symbarr.Length];
                for(int i=0;i<symbarr.Length;i++)
                        Symbols[i]=new Symbol(symbarr[i]);
                
                }
	}
}
