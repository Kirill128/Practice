using System;
using System.Text.RegularExpressions;
namespace Parser{
	class Text{
		public Sentens [] Sentenses{get;set;}
		public string Value{get;set;}
		public  Text(string txt){
            Value=txt;
			string[] allStr=txt.Split(new char[]{'.','!','?'});
            Regex reg=new Regex(@"\s+");
            int importantString=0;
            for(int i=0;i<allStr.Length;i++){
                allStr[i]=reg.Replace(allStr[i]," ");
                if(allStr[i]!=" ")importantString++;
            }
            Sentenses=new Sentens[importantString];
			for(int i=0;i<importantString;i++)
				if(allStr[i]!=" ")Sentenses[i]=new Sentens(allStr[i]);
		}
	}
}
   
