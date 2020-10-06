using System;
using System.Collections.Generic;
namespace _test
{
    class Programm
    {
		public static void Main(string[] args){
			LinkedList<Student>students=FileWorker.getstud();
			bool doWork=true;
			int taskNum;
			while(doWork){
				Console.WriteLine("1- input or change student notes\n2-show all students notes\n3-show the student success labs list\n4-student notes table ");
				taskNum=Convert.ToInt32(Console.ReadLine());
				switch(taskNum){
					case 1:{
						Console.Write("\nInput student num:");
						int numStud=Convert.ToInt32(Console.ReadLine());
						Console.Write("lab num:");
						int numLab=Convert.ToInt32(Console.ReadLine());
						Console.Write("task num:");
						int numTask=Convert.ToInt32(Console.ReadLine());
						Console.Write("note:");
						int note=Convert.ToInt32(Console.ReadLine());
						LinkedListNode<Student> node =students.First;
						if(numStud<=students.Count && numLab<=node.Value.Performance.Length && numTask<=node.Value.Performance[numLab-1].Length )
							for(int countStud=0;;countStud++){
								if(countStud+1==numStud){
									node.Value.Performance[numLab-1][numTask-1]=note;
									break;
								}
								node=node.Next;
							}
						else 
							Console.WriteLine("Doesn't exist!");
					}
					break;
					case 2:{
						showAllStudentsPer(students);
					}
					break;
					case 3:{
						LinkedListNode<Student>node =students.First;
						Console.Write("\nInput student num:");
						int numStud=Convert.ToInt32(Console.ReadLine());
						if(numStud<=students.Count)
							for(int countStud=0;;countStud++){
								if(countStud+1==numStud){
									int[][]per=node.Value.Performance;
									Console.Write("Success labs: ");
									bool successLabExist=false;
									for(int i=0;i<per.Length;i++){
										bool successLab=true;
										for(int j=0;j<per[i].Length && successLab;j++){
											if(per[i][j]<3)
												successLab=false;
										}
										
										if(successLab){
											Console.WriteLine((++i)+" ");
											successLabExist=true;
										}

									}
									if(!successLabExist)
										Console.WriteLine("No");
									break;
								}
								node=node.Next;
							}
						else 
							Console.WriteLine("Doesn't exist!");
					}
					break;
					case 4:{
						Console.Write("\nInput student num:");
						int numStud=Convert.ToInt32(Console.ReadLine());
						LinkedListNode<Student> node =students.First;
						for(int i=1;i<=students.Count;i++){
							if(i==numStud){
								showStudentPerf(node.Value);
								break;
							}
							node=node.Next;
						}
					}
					break;
					default:{
						Console.WriteLine("ERROR");
						doWork=false;
					}
					break;
				}
			}
		}
        public static void showAllStudentsPer(LinkedList<Student>students)
        {
			foreach(Student stud in students){
				showStudentPerf(stud);
			}	
		}
		public static void showStudentPerf(Student stud){
			Console.WriteLine(stud.Name);
				int [][] studper=stud.Performance;
				for(int i=0;i<studper.Length;i++){
					for(int j=0;j<studper[i].Length;j++){
						Console.Write(studper[i][j]+" ");
					}
					Console.WriteLine();
				}

		}
		
    }
}
