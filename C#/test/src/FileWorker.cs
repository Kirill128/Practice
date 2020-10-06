using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
namespace _test
{
	class FileWorker
	{//I:\\Practice\\C#\\test\\database\\            /home/kirill/Practice/C#/test/database/
		private static string pathToDatabase="I:\\Practice\\C#\\test\\database\\";

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
		public static LinkedList<Student> getStudFromTxt(){
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

		public static void saveTrueData(LinkedList<Student> students){	
			string fileName="SavedData.dat";
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream(pathToDatabase+fileName, FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, students);
				Console.WriteLine("Объект сериализован");
			}
		}
		public static LinkedList<Student> getTrueData(){
			string fileName="SavedData.dat";
			LinkedList<Student> res;
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream(pathToDatabase+fileName, FileMode.OpenOrCreate))
			{
				res = (LinkedList<Student>)formatter.Deserialize(fs);
			}
			return res;
		}
	}

}
