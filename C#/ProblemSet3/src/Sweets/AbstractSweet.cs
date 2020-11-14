using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSet3.src.Sweets
{
    abstract class AbstractSweet
    {
        private protected double proteinsIn100;
        private protected double fatsIn100;
        private protected double carbohydratesIn100;
        private protected double caloriesIn100;
        public string Name { get; set; }
        public virtual double Weight { get; set; }// in gramms

        private protected AbstractSweet(double protein, double fats, double carbohudrates, double calories) {
            this.proteinsIn100 = protein;
            this.fatsIn100 = fats;
            this.carbohydratesIn100 = carbohudrates;
            this.caloriesIn100 = calories;
        }

    }
}
