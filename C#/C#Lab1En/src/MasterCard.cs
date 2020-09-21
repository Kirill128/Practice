namespace C_Lab1En
{
    public class MasterCard :Card,IShowFirm
    {
        private string firmName="MasterCard";
        public string FirmName
        {
            get
            {
                return firmName;
            }

        }
        public MasterCard(Card card):base(card.CardNum)
        {}
       
    }
}
