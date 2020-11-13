using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSet3.src.Sweets
{
    class Ingridient
    {
        private double energyValueOn100;//ккал/кДж на 100 г
        private double sugarContentOn100;//содержание сахара 100 g
        public string Name { get; set; }
        public double Weight { get; set; }
        public double SugarContent { get; set; }
        public double EnegryValue { get; set; }

        public Ingridient(double enegryOn100,double sugarOn100,double weight,string name) {
            this.Name = name;
            this.Weight = weight;
            this.energyValueOn100 =enegryOn100;
            this.sugarContentOn100 = sugarOn100;
        }
    }
}
