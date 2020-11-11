using lab9.src;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
			string filePath = "I:\\Practice\\C#\\lab9\\lab9\\data\\TextFile1.txt";
			bool doWork = true;
			int taskNum;
			string inputedString = ReadFile(filePath);
			while (doWork)
			{
				Console.WriteLine("Input task num:");
				taskNum = Convert.ToInt32(Console.ReadLine());
				switch (taskNum)
				{
					case 1:
						{
							Console.WriteLine("Input Word");
							Console.WriteLine("Result:"+TextMethodes.ExistWordInString(inputedString,Console.ReadLine()));
						}
						break;
					case 2:
						{
							Console.WriteLine("Input length:");
							string pattern = String.Format(@"\s[a-zA-Z]{{0}}\s", getINT());
							LinkedList<string> founded = TextMethodes.FindByPattern(inputedString,pattern );
							foreach (string str in founded) {
								Console.WriteLine(str);
							}
						}
						break;
					case 3:
						{
							Console.WriteLine("Res:"+TextMethodes.DeleteWordsByPattern(inputedString, @"\b([a-zA-Zа-яА-Я]{1})\s"));
						}
						break;
					case 4:
						{
							Console.WriteLine("Res:"+ TextMethodes.DeleteWordsByPattern(inputedString, @"\b[ауеыоэяиюё][а-яА-Я]*\s"));
						}
						break;
					case 5:
						{
							Console.WriteLine("Res:"+TextMethodes.ReplaceByPattern(inputedString, @"\b[a-zA-Z]+\b", "..."));
						}
						break;
					case 6:
						{
							double res=0;
							double num;
							LinkedList<string> nums = TextMethodes.FindByPattern(inputedString,@"\d+.?\d*");
							foreach (string str in nums)
							{
								if (double.TryParse(str, out num))
									res += num;
								else
									res += int.Parse(str);
							}
							Console.WriteLine("Res:"+res);
						}
						break;
					case 7:
						{
							LinkedList<string> numbers = TextMethodes.FindByPattern(inputedString, @"([0-9]{2}-[0-9]{2}-[0-9]{2})|([0-9]{3}-[0-9]{3})|([0-9]{3}-[0-9]{2}-[0-9]{2})");
							foreach(string num in numbers)
								Console.WriteLine(num);
						}
						break;
					case 8:
						{
							LinkedList<string> numbers = TextMethodes.FindByPattern(inputedString, @"(10|20|[0-2][1-9]|3[0-1])\.(0[1-9]|1[0-2])\.((19[0-9][0-9])|(20([0-1][0-9])|(20)))");
							foreach (string num in numbers)
								Console.WriteLine(num);
						}
						break;

					case 9:
						{
							
						}
						break;
					case 10:
						{

						}
						break;
					case 11:
						{
							LinkedList<WordBox> wordsbox = TextMethodes.GetUniqueWordBoxes(ReadFileByLines(filePath));
							foreach (WordBox w in wordsbox) {
								Console.Write(w.Word +" "+w.Count+": ");
								foreach (int meet in w.MeetInLines) {
									Console.Write(meet+" ");
								}
								Console.WriteLine();
							}
						}
						break;


					default:
						{
							doWork = false;
						}
						break;
				}
			}
		}
		public static string ReadFile(string path)
		{
			try
			{
				StreamReader file = new StreamReader(path);
				return file.ReadToEnd();
			}
			catch (Exception e)
			{
				return null;
			}
		}
		public static LinkedList<string> ReadFileByLines(string filePath) {
			LinkedList<string> allLines = new LinkedList<string>();
			try
			{
				StreamReader file = new StreamReader(filePath);
				int lineNum = 0;
				for (string l = file.ReadLine(); l != null; l = file.ReadLine())
				{
					lineNum++;
					allLines.AddLast(l);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return allLines;
		}
		public static int getINT()
		{
			int wordlength = 0;
			try
			{
				wordlength = Convert.ToInt32(Console.ReadLine());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return wordlength;
		}
	}
}
