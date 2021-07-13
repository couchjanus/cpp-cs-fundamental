using System;

namespace cs
{
    class Student:Human
	{
		public string name = "I am Student";
	
		public void DisplayName()
		{
			Console.WriteLine("Student Display Name " + name);
		}

	}
}