namespace C_Lab1En
{
    public class Card:AbstractCard 
    {
        private string cardNum;
	    private bool isLegal;
        public override string CardNum
        {
            set
            {
                bool rightNum=true;
                for(int i=0;i<value.Length && rightNum;i++)
                {
                    if(value[i]<48 || value[i]>57)
                        rightNum=false;
                }
                if(rightNum) cardNum=value;
            }
            get
            {
                return cardNum;
            }
        }
	public bool IsLegal
	{
		private set
		{
	        isLegal=value;
		}
		get
		{
			return isLegal;
		}
	}
        public Card(string num)
        {
            CardNum=num;   
	    IsLegal=CheckCard.checkLegit(this);
        }   
    }
}
