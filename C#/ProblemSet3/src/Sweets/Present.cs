using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSet3.src.Sweets
{
    class Present
    {


        public LinkedList<Sweet> Sweets { get; set; }
        public double Weight {
            get {
                double w = 0;
                foreach (Sweet sw in Sweets) {
                    w += sw.Weight;
                }
                return w;
            }
        }
        public Present(LinkedList<Sweet> sweets) {
            this.Sweets = sweets;
        }
        
    }

}
