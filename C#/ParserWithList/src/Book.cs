using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ParserWithList
{
    class Book{
        public string FilePath{get;set;}
        public int maxLinesInPage{get;set;}
        public LinkedList<Page> Pages;
        public Book(string filePath,int linesInPage){
            FilePath=filePath;
            maxLinesInPage=linesInPage;
            Pages=divideToPages(readFileByLines(filePath),maxLinesInPage);
        }
        public static LinkedList<Page> divideToPages(LinkedList<Line> allLines,int maxLinesInPage){
            LinkedList<Page> pages=new LinkedList<Page>();
            Line[] linesForOnePage=new Line[maxLinesInPage];
            int lineCount=0;
            foreach(Line line in allLines){
                lineCount++;
                linesForOnePage[lineCount-1]=line;
                if(lineCount==maxLinesInPage){
                    pages.AddLast(new Page(linesForOnePage));
                    lineCount=0;
                    linesForOnePage=new Line[maxLinesInPage];
                }
            }
            return pages;
        }
        public static LinkedList<Line> readFileByLines(string filePath){
            LinkedList<Line> allLines=new LinkedList<Line>();
            try{
                StreamReader file=new StreamReader(filePath);                
                for(string l = file.ReadLine();l!=null;l = file.ReadLine()){
                    allLines.AddLast(new Line(l));
                } 
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return allLines;
        }
        
    }
}