using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSet3.src.Sweets
{
    class Sweet : AbstractSweet
    {
        public LinkedList<Ingridient> Ingridients { get; set; }
        public string NameGotedByFirm { get; set; }

        public override double SugarContent{
            get {
                double s = 0;
                foreach (Ingridient i in Ingridients) { 
                    
                }
            }
        }
    }
}
