namespace Parser{
	class Text{
		private Sentens [] sentens; 
		public  Text(string txt){
			string[] allStr=txt.Split(new char[]{'.'};
			sentens=new Sentens[allStr.Length];
			for(int i=0;i<allStr.Length;i++)
				new Sentens(sentens[i]);
		}
	}
}