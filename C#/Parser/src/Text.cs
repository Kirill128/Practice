using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace Parser{
	class Text{
		public Sentens [] Sentenses{get;set;}
		public string Value{get;set;}
		public  Text(string txt){
           		
			
			
			List<string> sentences = new List<string>();
			int position = 0;
			int start = 0;
// Extract sentences from the string.
				do 
				{
   position = txt.IndexOfAny(new char[]{'.','!','?'}, start);
   if (position >= 0) 
   {
      sentences.Add(txt.Substring(start, position - start + 1).Trim());
      start = position + 1;
   }
} while (position > 0);

// Display the sentences.
foreach (var sentence in sentences)
   Console.WriteLine(sentence);
			
				
			string [] allStr=sentences.ToArray();
			
			
			Value=txt;
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
   
