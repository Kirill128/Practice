namespace C_Lab1En
{
    public class VisaCard :Card,IShowFirm
    {
        private string firmName="VisaCard";
        public string FirmName
        {
            get
            {
                return firmName;
            }

        }
        public VisaCard(Card card):base(card.CardNum)
        {
            
        }
        
    }
}
