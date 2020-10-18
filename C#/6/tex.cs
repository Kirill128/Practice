using System;
					
public class Program
{
	public static void Main()
	{
		int [][]arr=makeArr();
		if(arr.Length%2==0)
		{
			arr=changeColum(arr,arr.Length/2-1,arr.Length/2);
		}
		else 
		{
			arr=changeColum(arr,0,arr.Length/2);
		}
		for(int i=0;i<arr.Length;i++)
		{
			for(int j=0;j<arr.Length;j++)
			{
				Console.Write(arr[i][j]+" ");
			}
			Console.WriteLine("\n");
		}
	}
	
	public static int[][] changeColum(int [][] arr ,int firstCol,int lastCol)
	{
		for(int i=0,buf;i<arr.Length;i++)
		{	
			buf=arr[i][firstCol];	
			arr[i][firstCol]=arr[i][lastCol];
			arr[i][lastCol]=buf;
		}
		return arr;
	}
	public static int[,] makeArr()
	{
		Console.WriteLine("Input num of line/colum:");
		int quantityLine=Convert.ToInt32(Console.ReadLine());
		int [,] arr=new int [quantityLine][];
		for(int i=0;i<quantityLine;i++)
			arr[i]=new int[quantityLine];
		Random rand=new Random();		
		for(int i=0;i<quantityLine;i++)
		{
			
			for(int j=0;j<quantityLine;j++)
			{
				arr[i][j]=rand.Next(-100,100);
				Console.Write(arr[i][j] + " ");
			}
			Console.WriteLine("\n");
		}
		Console.WriteLine("\n \n");
	 	return arr;
	 }
	  
	
}
