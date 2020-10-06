using System;
using System.Collections.Generic;
namespace _test
{
    class Programm
    {
	public static void Main(string[] args){
		LinkedList<Student>students=FileWorker.getstud();
		LinkedListNode<Student> node =students.First;

	}
        public static void showStudents()
        {
		LinkedList<Student>students=FileWorker.getstud();
		LinkedListNode<Student> node=students.First;
		foreach(Student stud in students){
			Console.WriteLine(node.Value.Name);
			int [][] studper=node.Value.Performance;
			node=node.Next;
			for(int i=0;i<studper.Length;i++){
				for(int j=0;j<studper[i].Length;j++){
					Console.Write(studper[i][j]+" ");
				}
				Console.WriteLine();
			}
		}	
	}
    }
}
