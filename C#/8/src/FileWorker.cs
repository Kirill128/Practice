using System;
using System.IO;
using System.Collections.Generic;
namespace _8
{
	class FileWorker
	{
		private static string pathToDatabase="/home/kirill/Practice/C#/8/database/";
		public static List<int[]> getPerformance(int[] taskNum)
		{
			
			List <int[]> res=new List<int[]>();
			string fileName="performance.txt";
			if(taskNum==null)
				return null;
			try
			{
				StreamReader file= new StreamReader(pathToDatabase+fileName);
				string first;
				for(first=file.ReadLine();first!=null;first=file.ReadLine());
				{
					string[] sec=first.Split(new char[]{' '});
					int [] third=new int[sec.Length];
					for(int i=0;i<sec.Length;i++)
					{
						third[i]=Convert.ToInt32(sec[i]);
					}
					res.Add(third);

				}
				file.Close();
				return res;
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		
		}
		public static int[] labNum()
		{
			string fileName="labsnum.txt";
			try
			{
				StreamReader file=new StreamReader(pathToDatabase+fileName);
				int [] res=new int[Convert.ToInt32(file.ReadLine())];
				string[]nums=file.ReadLine().Split(new char[]{','});
				for(int i=0;i<res.Length;i++)
				{
					res[i]=Convert.ToInt32(nums[i]);
				}
				file.Close();
				return res;
				

			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}	
		}
		public static  List<Student> getStudents()
		{
			string filePath="name.txt";
			int []taskNum=labNum();
			List<int[]> performance=getPerformance(taskNum);
			foreach(int[] arr in performance)
			{
				for(int j=0;j<arr.Length;j++)
				{
					Console.Write($"{arr[j]} ");
				}
				Console.WriteLine();
			}
		/*	try
			{
				StreamReader file=new StreamReader(pathToDatabase+filePath);
				List<Student> res=new List<Student>();
				string s=file.ReadLine();
				for(int countStudent=0;s!=null ;s=file.ReadLine() ,countStudent++)
				{	
					int [][]OneStud =new int[taskNum.Length][];
					for(int countLabs=0;countLabs<taskNum.Length;countLabs++)
					{
						OneStud[countLabs]=new int[taskNum[countLabs]];
						for(int countNum=0;countNum<taskNum[countLabs];countNum++)
						{
							OneStud[countLabs][countNum]=performance[countStudent*taskNum.Length+countLabs][countNum];
						}
					}
					res.Add(new Student(s,OneStud));
				}
						
				Console.WriteLine("SDFS");
				return res;
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			} */
			return null;
		}
	}
}	
