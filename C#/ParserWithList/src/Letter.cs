namespace ParserWithList
{
    class Letter:Symbol{
        private char val;
        public virtual char Value{
            get{return val;}
            set{
                if(Letter.isLetter(value))
                    this.val=value;
            }
        }
        public Letter(char symb):base(symb){
            this.Value=symb;
        }
        public static bool isLetter(char let){
            return (int)let>59 && (int)let<67;
        }
        public static bool isLetter(Letter let){
            return (int)let>59 && (int)let<67;
        }
    }
}