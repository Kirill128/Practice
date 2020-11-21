using System;
using System.Collections.Generic;
using System.IO;
using ProblemSet3.src.Sweets;

namespace ProblemSet3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string filePath= "I:\\Practice\\C#\\ProblemSet3\\database\\Sweets.txt";
            LinkedList<Sweet> allSw = getAllSweets(filePath);
            
            Present[] presents = new Present[2];
            for (int i = 0; i < presents.Length; i++)
            {
                presents[i] = randomPresent(allSw);
                Console.WriteLine($"Weight of present {i}: {presents[i].Weight}");
                foreach (Sweet sw in presents[i].Sweets)Console.WriteLine(sw.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("//////////////");
            for (int i = 0; i < presents.Length; i++)
            {
                presents[i].SortComparator((Sweet a,Sweet b)=> a.Weight>b.Weight);
                foreach (Sweet sw in presents[i].Sweets) Console.WriteLine(sw.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("//////////////");
            for (int i = 0; i < presents.Length; i++)
            {
                foreach (Sweet sw in presents[i].findSomeSweets((Sweet a)=> a.CaloriesContent<100 )) Console.WriteLine(sw.ToString());
                Console.WriteLine();
            }

        }
        public static LinkedList<Sweet> getAllSweets(string filePath) {
            LinkedList<Sweet> allSweets = new LinkedList<Sweet>();
            try
            {
                StreamReader file = new StreamReader(filePath);
                string line = file.ReadLine();
                
                while (line != null) {
                    string[] ch = line.Split(new char[] {'/'});
                    allSweets.AddLast(new Sweet(ch[0],0,Convert.ToDouble(ch[1]), Convert.ToDouble(ch[2]), Convert.ToDouble(ch[3]), Convert.ToDouble(ch[4])));
                    line =file.ReadLine();
                }

            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
            return allSweets;
        } 
        public static Present randomPresent(LinkedList<Sweet> allSweetsList) 
        {
            Sweet[] allSweetsArr = new Sweet[allSweetsList.Count];
            
            int strcount = 0;
            foreach (Sweet s in allSweetsList)
                allSweetsArr[strcount++] = s;
            
            Random rand = new Random();
            int presentLength = rand.Next(1,allSweetsArr.Length-1);
            int sweetnum,sweetweight;
            LinkedList<Sweet> sweets = new LinkedList<Sweet>();
            while (presentLength--!=0) {
                sweetnum = rand.Next(0,allSweetsArr.Length);
                sweetweight = rand.Next(10,500);
                sweets.AddLast(allSweetsArr[sweetnum]);
                allSweetsArr[sweetnum].Weight = sweetweight;
            }
            return new Present(sweets);
        }
    }
}
