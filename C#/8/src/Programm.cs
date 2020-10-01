using System;
using System.Collections.Generic;
namespace _8
{
    class Programm
    {
        public static void Main(string[] args)
        {	
		List<Student> students=FileWorker.getStudents();
		if(students!=null){
		  foreach(Student stud in students)
		  {
			Console.WriteLine($"{stud.Name}");
			for(int i=0;i<stud.Performance.Length;i++)
			{
				for(int j=0;j<stud.Performance[i].Length;j++)
				{
					Console.Write($"{stud.Performance[i][j]} ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		  }
		}else 
			Console.WriteLine("SFDFS");
	}
    }
}
