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
			string filePath = "I:\\Practice\\C#\\lab9\\Lab9\\data\\TextFile1.txt";
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
							LinkedList<string> numbers = TextMethodes.FindByPattern(inputedString, @"(10|20|[0-2][1-9]|3[0-1])\.(0[1-9]|1[0-2])\.2020");
							foreach (string num in numbers)
								Console.WriteLine(num);
						}
						break;

					case 9:
					{
						LinkedList<string> adresses = TextMethodes.FindByPattern(inputedString, @"\w+(\.by|\.com)");
						foreach (string str in adresses)
						{
							Console.WriteLine(str);
						}
					}
						break;
					case 10:
					{
						string pattern = @"(([0-1][0-9])|(2[0-4])):(([0-5][0-9])|(60)):(([0-5][0-9])|(60))";
						
						MatchCollection matches = Regex.Matches(inputedString,pattern);
							foreach (Match match in matches)
								Console.WriteLine("|"+match.Value+"|");
							int wordCount = 0;
							foreach (Match match in matches)
						{
								
							string time=match.Value;
							int index = match.Index-wordCount*3;
							
							if (Regex.IsMatch(time, @"(([0-1][0-9])|(2[0-4])):60:(([3-5][0-9])|(60))"))
							{
									Console.WriteLine("Reg1");
									Regex reg1 = new Regex(@"(([0-1][0-9])|(2[0-4])):60:(([3-5][0-9])|(60))");
									int hours = Convert.ToInt32(String.Concat(time[0],time[1]));
									
								    hours++;
									inputedString = reg1.Replace(inputedString,String.Concat(hours,":00"),1,index);
									wordCount++;
							}
							else
							{
								if (Regex.IsMatch(time,@"(([0-1][0-9])|(2[0-4])):([0-5][0-9]):([0-2][0-9])"))
								{
										Console.WriteLine("Reg2");
										Regex reg2 = new Regex(@"(([0-1][0-9])|(2[0-4])):([0-5][0-9]):([0-2][0-9])");
										inputedString=reg2.Replace(inputedString,String.Concat(time[0],time[1],time[2],time[3],time[4]),1,index);
										wordCount++;
								}
								else
								{
										Console.WriteLine("Reg3");
										int minutes = Convert.ToInt32(String.Concat(time[3],time[4]));
										minutes++;
										Regex reg3 = new Regex(@"(([0-1][0-9])|(2[0-4])):([0-5][0-9]):([3-5][0-9])");
										inputedString = reg3.Replace(inputedString,String.Concat(time[0],time[1],time[2],(minutes>9)?minutes.ToString():String.Concat("0",minutes)),1,index);
										wordCount++;
								}	
							}
							
						}
							Console.WriteLine(inputedString);
					}
						break;
					case 11:
						{
							LinkedList<WordBox> wordsbox = TextMethodes.sortWordsByAlphabet(TextMethodes.GetUniqueWordBoxes(ReadFileByLines(filePath)));
							
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
