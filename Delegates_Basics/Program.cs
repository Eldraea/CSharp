using System;
using System.Collections.Generic;

namespace Delegates_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> names = new List<string>() { "Beatrice", "Bill", "Budd", "Elle", "Oren" };
            Console.WriteLine("Here is our list before the remove:");

            foreach (String name in names)
                Console.WriteLine(name);

            names.RemoveAll(Filter);

            Console.WriteLine("\nHere is our list after the remove");

            foreach (String name in names)
                Console.WriteLine(name);


        }

        public static bool Filter(String s)
        {
            return s.Contains("i");
        }
    }
}
