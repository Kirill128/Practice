using System;
using System.Collections.Generic;
using System.Text;

namespace ParserWithList.src
{
    class Page{
        public int NumOfPage{get;set;}
        Line[] Lines {get;set;}
        public Page(Line[] lines){
            Lines = lines;
        }
        public Page(Line[] lines,int pageNum){
            Lines=lines;
            NumOfPage=pageNum;
        }
        
    }
}