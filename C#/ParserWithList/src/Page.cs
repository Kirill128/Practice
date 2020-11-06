using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ParserWithList
{
    class Page{
        public int NumOfPage{get;set;}
        public Line[] Lines {get;set;}
        public Page(Line[] lines){
            Lines = lines;
        }
        public Page(Line[] lines,int pageNum){
            Lines=lines;
            NumOfPage=pageNum;
        }
        
    }
}