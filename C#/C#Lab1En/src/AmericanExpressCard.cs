namespace C_Lab1En
{
    public class AmericanExpressCard :Card,IShowFirm
    {
        private string firmName="AmericanExpressCard";
        public string FirmName
        {
            get
            {
                return firmName;
            }

        }
        public AmericanExpressCard(Card card):base(card.CardNum)
        { }
        
    }
}
