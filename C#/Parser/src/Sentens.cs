namespace Parser{
	class Sentens{
        public Word [] Words{get;set;}
        public string Value{get;set;} 
		public Sentens(string txt){
            Value=txt;
			string[] allStr=txt.Split(new char[]{' ',',','-',':'});
			Words=new Word[allStr.Length];
			for(int i=0;i<allStr.Length;i++)
				Words[i]=new Word(allStr[i]);
		}
	}
}
