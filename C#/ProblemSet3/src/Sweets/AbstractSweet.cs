using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSet3.src.Sweets
{
    abstract class AbstractSweet
    {
        public string Type { get; set; }// type of sweet
        public double Weight { get; set; }
        public virtual double SugarContent { get; set; }//Содержание сахара
        public virtual double EnegryValue { get; set; }
    }
}
