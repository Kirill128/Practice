using System;
using System.Collections.Generic;

namespace C_Lab1En
{
    public class Program
    {
        static void Main(string[] args)
        {
           List<IShowFirm> cardList=new List<IShowFirm>();
	   makeCard(ref cardList);
	   foreach(IShowFirm a in cardList)
	   {
	   	Console.WriteLine(a.FirmName);
	   }
        }
        
        static void makeCard(ref List<IShowFirm> cardList)
        {
	   string workInput;
	   while(true){
	   	 Console.WriteLine("Want to input(no if you don't):");
	      	 workInput=Console.ReadLine();
		 if(workInput=="n" || workInput=="no" || workInput=="No")
			break;	 
             	 Console.WriteLine("Input num:");
               	 Card card1=new Card(Console.ReadLine());   
           	 Console.WriteLine($"Legit:{card1.IsLegal}");
            
            	if(CheckCard.checkFirmVisa(card1))
            	{
                	VisaCard visacard=new VisaCard(card1);
      	                Console.WriteLine($"Firm:{visacard.FirmName}");
			cardList.Add(visacard);
            	}
            	if(CheckCard.checkFirmAmericanExpress(card1))
            	{
                	AmericanExpressCard amercard=new AmericanExpressCard(card1);
                	Console.WriteLine($"Firm:{amercard.FirmName}");
			cardList.Add(amercard);
            	}
            	if(CheckCard.checkFirmMasterCard(card1))
            	{
                	MasterCard mastcard=new MasterCard(card1);
                	Console.WriteLine($"Firm:{mastcard.FirmName}");	
			cardList.Add(mastcard);
	    	}
	    }
        }
    }

    
}
