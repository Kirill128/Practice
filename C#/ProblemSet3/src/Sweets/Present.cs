using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemSet3.src.Sweets
{
    class Present
    {
        public delegate bool Comparator(Sweet a,Sweet b);

        public delegate bool FindCondition(Sweet a);
        public LinkedList<Sweet> Sweets { get;  }
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

        public void addSweet(Sweet a) {
            Sweets.AddLast(a);
        }
        public void removeSweet(Sweet a) {
            Sweets.Remove(a);        
        }
        public LinkedList<Sweet> findSomeSweets(FindCondition condition) {
            LinkedList<Sweet> resSweets=new LinkedList<Sweet>();
            foreach (Sweet s in this.Sweets) {
                if (condition(s)) resSweets.AddLast(s);
            }
            return resSweets;
        }
        /*public void Sort() {
            for (LinkedListNode<Sweet> firstIter = this.Sweets.First; firstIter != null; firstIter = firstIter.Next)
            {
                for (LinkedListNode<Sweet> secondIter = firstIter; secondIter != null; secondIter = secondIter.Next)
                {
                    if (firstIter.Value.CaloriesContent>secondIter.Value.CaloriesContent)
                    {
                        Sweet buf = firstIter.Value;
                        firstIter.Value = secondIter.Value;
                        secondIter.Value = buf;
                    }
                }
            }
        }*/
        public void SortComparator(Comparator comparator)
        {
            for (LinkedListNode<Sweet> firstIter = this.Sweets.First; firstIter != null; firstIter = firstIter.Next)
            {
                for (LinkedListNode<Sweet> secondIter = firstIter; secondIter != null; secondIter = secondIter.Next)
                {
                    if (comparator(firstIter.Value, secondIter.Value))
                    {
                        Sweet buf = firstIter.Value;
                        firstIter.Value = secondIter.Value;
                        secondIter.Value = buf;
                    }
                }
            }
        }
    }

}
