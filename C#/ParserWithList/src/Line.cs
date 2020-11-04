using System;
using System.Collections.Generic;
using System.Text;

namespace ParserWithList.src
{
    class Line
    {
        LinkedList<Word> Words { get; set; }
        LinkedList<PunctuationSymbol> PunctuationSymbols { get; set; }


    }
}
