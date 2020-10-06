using System;
using System.IO;
using System.Collections.Generic;
namespace _test
{
	class FileWorker
	{//I:\\Practice\\C#\\8\\database\\            /home/kirill/Practice/C#/8/database/
		private static string pathToDatabase="/home/kirill/Practice/C#/test/database/";
		/*public static int[][] getPerformance(int[] taskNum)
		{
			int [][]res;
			string fileName="performance.txt";
			if(taskNum==null)
				return null;

			res=new int[taskNum.Length][];
			for(int i=0;i<taskNum.Length;i++)
				res[i]=new int[taskNum[i]];
				
			try
			{
				StreamReader file= new StreamReader(pathToDatabase+fileName);
				for(int i=0;i<res.Length;i++)
				{
					string[] s=file.ReadLine().Split(new char[]{' '});
					for(int j=0;j<res[i].Length;j++)
					{
						res[i][j]=Convert.ToInt32(s[j]);
					}
				}
				file.Close();
				return res;
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		
		}*/
		public static LinkedList<int[]> getper()
		{
			string fileName="performance.txt";
			LinkedList<int[]> res=new LinkedList<int[]>();
			try
			{
				StreamReader file=new StreamReader(pathToDatabase+fileName);
				string line=file.ReadLine();
				int[]buf;
				while(line!=null){
					string[] strNum=line.Split(new char[]{' '});
					buf=new int[strNum.Length];
					for(int i=0;i<strNum.Length;i++)
						buf[i]=Convert.ToInt32(strNum[i]);
					res.AddLast(buf);
					line=file.ReadLine();
				}
			}
			catch(Exception e){
				Console.WriteLine(e.Message);
			}
				return res;
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
		public static LinkedList<string> getname()
		{
			LinkedList<string> names=new LinkedList<string>();
			string fileName="name.txt";
			try {
				StreamReader file=new StreamReader(pathToDatabase+fileName);
				string name;
				while((name=file.ReadLine())!=null){
					names.AddLast(name);
				}
			}
			catch(Exception e){
				Console.WriteLine(e.Message);
			}
				return names;

		}
		public static LinkedList<Student> getstud(){
			int[]labs=labNum();
			LinkedList<int[]>per=getper();
			LinkedList<string> names=getname();
			LinkedList<Student> students=new LinkedList<Student>();
			int studCount=0;
			LinkedListNode<int[]> node=per.First;
			foreach(string oneName in names){
				int[][] onePer=new int[labs.Length][];
				for(int i=0;i<labs.Length;i++){
					onePer[i]=node.Value;
					node=node.Next;
				}
				students.AddLast(new Student(oneName,onePer));
				studCount++;
			}
			return students;
		}
	/*	public static  List<Student> getStudents()
		{
			string filePath="name.txt";
			int []taskNum=labNum();
			int [][] performance=getPerformance(taskNum);
			try
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
					
				return res;
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}
		*/
	}
}
