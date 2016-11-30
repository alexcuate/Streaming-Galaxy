using System;

namespace LinkedList
{
	public class Program
	{
		static void Main(string[] args)
		{           
			LinkedList lnklist = new LinkedList();
			lnklist.Print_Nodes();
			Console.WriteLine();
			lnklist.Add_Node("First");
			lnklist.Add_Node("Second");
			lnklist.Add_Node("Third");
			lnklist.Add_Node("Fourth");
			lnklist.Print_Nodes();
			Console.WriteLine();
			lnklist.Add_Start("Zer0");
			lnklist.Print_Nodes();
			Console.WriteLine();
			lnklist.Remove_Node();
			lnklist.Print_Nodes();
			Console.ReadKey();
		}
	}
}

