using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input task num:");
	    string strTaskNum=Console.ReadLine();
	    int TaskNum;
	    if(Int32.TryParse(strTaskNum,out TaskNum))
	    {
	    	switch(TaskNum)
		{
		case 1:
		{
			Console.WriteLine("Input x:");
			double x=Convert.ToDouble(Console.ReadLine());
			if(x>3 || x<-3){
				Console.WriteLine($"z1={task1_1(x)}\nz2={task1_2(x)}");
			}	
			else 
			{
				Console.WriteLine("Incorrect num!");
			}
		}
		break;		
		case 2:
		{
			Console.WriteLine("Input x:");
			double x=Convert.ToDouble(Console.ReadLine());
			double res=task2(x);
			if (res!=-1)
				Console.WriteLine($"Res:{res}");
			else 
				Console.WriteLine("False !!!!!!!!!!!");
		}
		break;
		case 3:
		{
			Console.WriteLine("Input x:");
			double x=Convert.ToDouble(Console.ReadLine());
			Console.WriteLine("Input y:");
			double y=Convert.ToDouble(Console.ReadLine());
			Console.WriteLine($"{task3(x,y)}");
			
		}
		break;
		case 4:
		{
			int currentDay=9,resDay;
			int currentMonth=9,resMonth;
			int currentYear=2020,resYear;
			Console.WriteLine("Input n:");
			int n=Convert.ToInt32(Console.ReadLine());
			task4(n, currentDay, currentMonth, currentYear,out resDay,out resMonth,out resYear);
			Console.WriteLine($"Day:{resDay}\nMonth:{resMonth}\nYear:{resYear}");
		}
		break;
		default:
		{
			Console.WriteLine("OOhh,it's a trap!");


		}
		break;


		}
	    }

        }
	static double task1_1(double x)
	{
		double x2=x*x;
		double sqrt=Math.Sqrt(x2-9);
		return ((x2+2*x-3)+(x+1)*sqrt)/((x2-2*x-3)+(x-1)*sqrt);
	}
	static double task1_2(double x)
	{
		return Math.Sqrt((x+3)/(x-3));
	}
	static double task2(double x)
	{
		if(x<=7 && x>=-9)
		{
			if(x<=-7)
				return 0;
			else 
			{	if(x<=-3)
					return x+7;
			
				else
				{	if(x<=-2)
						return 4;
					else
					{       if(x<=2)
							return x*x;
						else
						{       if(x<=4)
								return -2*x+8;
							else
							       return 0;
						}
					}
				}
			}
		}	
		
		return -1;
	}
	static string task3(double x,double y)
	{
		if(x<50 && x>-50 && y<25 && y>-25 )
			return "In";
		else 
			if(y==25 || y==-25 || x==50 || x==-50 )
				return "On border";
			else 
				return "Out";

	}
	static void task4(int n, int day, int month, int year,out int resDay,out int resMonth,out int resYear)
	{
		int [] months=new int[12]{31,28,31,30,31,30,31,31,30,31,30,31};
		while(n>0)
		{
		   
		   if(day<=n)
		   {
			n-=day;
			if(month ==1 )
			{
				year--;
				month=12;
			}
			else 
				month--;
			switch(month)
			{
				case 1:
				{
					day=months[0];
				}
				break;
				case 2:
				{
					day=months[1];
					
				}
				break;
				case 3:
				{
					day=months[2];
				}
				break;
				case 4:
				{
					day=months[3];
				}
				break;
				case 5:
				{
					day=months[4];
				}
				break;
				case 6:
				{
					day=months[5];
				}
				break;
				case 7:
				{
					day=months[6];
				}
				break;
				case 8:
				{
					day=months[7];
				}
				break;
				case 9:
				{
					day=months[8];
				}
				break;
				case 10:
				{
					day=months[9];
				}
				break;
				case 11:
				{
					day=months[10];
				}
				break;
				case 12:
				{	
					day=months[11];
				}
				break;
	
			}
		   }
		   else 
		   {
		   	day-=n;
			n=0;
		   }

		}
		resDay=day;
		resMonth=month;
		resYear=year;

    	}
    }
}
