using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
		Console.WriteLine("Task 1 ,Input min num of range ");
		int min=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Task 1 ,Input max num of range:");
		int max=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine($"Task 1, res:{sum(min ,max)}");
       

		Console.WriteLine($"Task2 ,res:arr[{lastMax()}]");
	}
	
	static int lastMax()
	{
		Console.WriteLine("Task 2  ");
		int [] arr=randArr();
		int max=arr[0];
		int maxIndex=0;
		for(int i=0;i<arr.Length;i++)
		{
			Console.WriteLine($"arr[{i}]={arr[i]}");
			if(arr[i]>=max)
			{
				maxIndex=i;
				max=arr[i];
			}
		}
		return maxIndex;
	}
	static int sum(int min,int max )
	{
		int sum=0;
		int [] arr= randArr();	
		foreach(int i in arr)
		{
			if(i>=min && i<=max)
				sum+=i;
			Console.WriteLine($"arr[n]={i}");
		}
		return sum;
	}
	static int[]  randArr()
	{		
		Console.WriteLine("Input num of members:");
		int [] arr= new int[Convert.ToInt32(Console.ReadLine())];
		Console.WriteLine("INput min rand ,after max rand");
		int min=Convert.ToInt32(Console.ReadLine());
		int max=Convert.ToInt32(Console.ReadLine());
		Random rnd=new Random();
		if(min<max)
			for(int i=0; i<arr.Length;i++)
			{
				arr[i]=rnd.Next(min,max);
			}
		return arr;
	}
    }
}
