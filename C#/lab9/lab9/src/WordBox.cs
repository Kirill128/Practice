using System;
using System.Collections.Generic;
using System.Text;

namespace lab9.src
{
    class WordBox
    {
        public int Count { get; set; }
        public LinkedList<int> MeetInLines { set; get; }
        public string Word { get; set; }

        public WordBox(string w)
        {
            this.Count = 1;
            this.Word = w;
        }
        public WordBox(string w, int meetInLines) : this(w)
        {
            this.MeetInLines = new LinkedList<int>();
            this.MeetInLines.AddLast(meetInLines);
        }
    }
}
