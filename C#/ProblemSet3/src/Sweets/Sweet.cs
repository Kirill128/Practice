using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSet3.src.Sweets
{
    class Sweet : AbstractSweet
    {
        private double weight;//in gramms
        public Sweet(string name,double weight,double protein,double fats,double carbohudrates,double calories):base(protein,fats,carbohudrates,calories)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public override double Weight { 
            get
            {
                return weight;
            }
            set {
                weight = value;
                double weightIn100 = value / 100;
                ProteinContent = proteinsIn100 * weightIn100;
                FatsContent = fatsIn100 * weightIn100;
                CaloriesContent = caloriesIn100 * weightIn100;
                CarbohydratesContent = carbohydratesIn100 * weightIn100;
            } 
        }
        public  double ProteinContent { get; private set; }
        public double FatsContent { get; private set; }
        public  double CarbohydratesContent {  get;private set; }
        public  double CaloriesContent { get;private set; }

        public override string ToString()
        {
            return "Name:" + String.Format("{0,-35}", Name) + " " +
                  "Weight:" + String.Format("{0,-4}", Weight) + " " +
                  "ProteinContent:" + String.Format("{0,-20}",String.Format("{0:f2}",ProteinContent)) + " " +
                  "FatsContent:" + String.Format("{0,-30}", String.Format("{0:f2}", FatsContent)) + " " +
                  "Calories:" + String.Format("{0,-30}", String.Format("{0:f2}", CaloriesContent)) + " " +
                  "Carbohydrates:" + String.Format("{0,-30}", String.Format("{0:f2}", CarbohydratesContent)) ;
        }
        public string allStandart() { 
            return "ProteinContent:" + String.Format("{0:f2}", proteinsIn100) + " " +
                  "FatsContent:" + String.Format("{0:f2}", fatsIn100) + " " +
                  "Calories:" + String.Format("{0:f2}", caloriesIn100) + " " +
                  "Carbohydrates:" + String.Format("{0:f2}", carbohydratesIn100);
        }
    }
}
