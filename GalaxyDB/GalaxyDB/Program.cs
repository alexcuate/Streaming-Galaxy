using System;
using System.Linq;
using System.Threading.Tasks;

using GalaxyDB.HashBuilder;
using GalaxyDB.Generics;

namespace GalaxyDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(5);
            Console.WriteLine(list.ToString());
            list.Add(6);
            Console.WriteLine(list.ToString());
            list.Remove();
            Console.WriteLine(list.ToString());
            list.AddFirst(8);
            Console.WriteLine(list.ToString());
            list.AddFirst(9);
            Console.WriteLine(list.ToString());

            Console.ReadLine();
        }
    }
}
