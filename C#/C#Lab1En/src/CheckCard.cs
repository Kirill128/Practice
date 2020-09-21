
namespace C_Lab1En
{   
    public class CheckCard
    {
       	public  static bool checkLegit(Card card)
        {
            string num=card.CardNum;
            int sum=0;
            for(int i=0;i<num.Length;i+=2)
                sum+=(int)num[i]-48;
            for(int i=1,buf;i<num.Length;i+=2)
            {
                buf=((int)num[i]-48)*2;
                if(buf>9)
                    sum++;
                sum+=buf%10;
            }
            if(sum%10==0)
                return true;
            return false;

        }
       	public static bool checkFirmVisa(Card card)
        {
            string num=card.CardNum;
            if(num[0]=='4' && (num.Length==13 || num.Length==16))
                return true;
            return false;
        }
        public static bool checkFirmMasterCard(Card card)
        {
            string num=card.CardNum;
            if(num[0]=='5' && num[1]>'0' && (int)num[1]<54 && num.Length==16)
                return true;
            return false;
        }
        public static bool checkFirmAmericanExpress(Card card)
        {
            string num=card.CardNum;
            if(num[0]=='3' && ((int)num[1]==55||(int)num[1]==52) && num.Length==15)
                return true;
            return false;
        }
        
    }
}
