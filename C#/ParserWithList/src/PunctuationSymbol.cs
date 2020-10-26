namespace ParserWithList
{
	class PunctuationSymbol:Symbol {
        private char val;
        public override char Value{
            get{return val;}
            set{
                if(PunctuationSymbol.IsPunctuationSymbol(value))
                this.val=value;
            }
        }
        public PunctuationSymbol(char s):base(s){
            Value=s;
        }
        public static bool IsPunctuationSymbol(char value){
            return ( value==',' || value==':' || value=='!' || value=='?' || value=='-' || value=='.' );
        }
        public static bool IsPunctuationSymbol(PunctuationSymbol symb)
        {
            return (symb.Value == ',' || symb.Value == ':' || symb.Value == '!' || symb.Value == '?' || symb.Value == '-' || symb.Value == '.');
        }
    }
}
