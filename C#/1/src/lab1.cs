using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input task num:");
	    string strtaskNum=Console.ReadLine();
            int taskNum;
	    if(Int32.TryParse(strtaskNum,out taskNum)){
		switch(taskNum)
		{
			case 1:
			{
				Console.WriteLine("Input a:");
				int a=Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Input b:");
				int b=Convert.ToInt32(Console.ReadLine());
				Console.WriteLine($"{a}+{b}={task1(a,b)}");	
			}
			break;
			case 2:
			{
				Console.WriteLine("Input a:");
				int a=Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Input b:");
				int b=Convert.ToInt32(Console.ReadLine());
				Console.WriteLine($"{a}+{b}={b}+{a}");	
			}
			break;	
			case 3:
			{
				Console.WriteLine("Input a:");
				int a=Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Input b:");
				int b=Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Input c:");
				int c=Convert.ToInt32(Console.ReadLine());
				Console.WriteLine($"{a}+{b}+{c}={task3(a,b,c)}");	
				
			}
			break;
			case 4:
			{
				Console.WriteLine("Input a:");
				double a=Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Input b:");
				double b=Convert.ToDouble(Console.ReadLine());
				string res=String.Format("{0:f1}",task4(a,b));
				Console.WriteLine($"Res:{res}");	
			}
			break;
			case 5:
			{
				Console.WriteLine("Input a:");
				double a=Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Input b:");
				double b=Convert.ToDouble(Console.ReadLine());
				string res=String.Format("{0:f3}",task5(a,b));
				Console.WriteLine($"Res:{res}");	
				
			}
			break;
			case 6:
			{	
				Console.WriteLine("Input a:");
				double a=Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Input b:");
				double b=Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Input c:");
				double c=Convert.ToDouble(Console.ReadLine());
				string sA,sB,sC;
				sA=String.Format("{0:f2}",a);
				sB=String.Format("{0:f2}",b);
				sC=String.Format("{0:f2}",c);
				Console.WriteLine($"<{sA}+{sB}>+{sC}={sA}+<{sB}+{sC}>");	
					
			}
			break;
			case 7:
			{
			}
			break;
			case 8:
			{
				
				Console.WriteLine("{0:X}",12);	
				Console.WriteLine("{0:X}",256);
				Console.WriteLine("{0:X}",1001);
				Console.WriteLine("{0:X}",123456789);

			}
			break;
			case 9:
			{
				Console.WriteLine("   sdfs\nksfjds\nsdfsd\n\tsdfj");
			}
			break;
			default:
				Console.WriteLine("Sorry, another num");
			break;
		}
	    }
	    else
	    {
		Console.WriteLine("Error");
	    }	

        }
	static int task1(int a,int b)
	{
		return a+b;
	}
	static int task3(int a,int b,int c)
	{
		return a+b+c;
	}	
	static double task4(double a,double b)
	{
		return a*b;
	}	

	static double task5(double a,double b)
	{
		return a/b;
	}	
    }
}
