namespace _test
{
	class Student
	{
		private int[][] performance;
		private string name;
		public string Name
		{
			set
			{
				name=value;
			}
			get
			{
				return name;
			}
		}
		public int [][] Performance
		{
			get
			{
				return performance;	
			}
			set
			{
				performance =value;
			}
		}
		public Student()
		{
		
		}
		public Student(string name)
		{
			this.Name=name;
		}
		public Student(string name,int [][] perf)
		{
			this.Name=name;
			this.Performance=perf;
		}


	}
}
