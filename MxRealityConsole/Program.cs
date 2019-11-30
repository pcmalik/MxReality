using MxRealityConsole.Models;
using System;

namespace MxRealityConsole
{
    partial class Program
    {

        static void Main(string[] args)
        {
            string[] string1 = { "def", "jkl" };
            string[] string2 = { "abc", "ghi" };
            string[] string3 = { "qrst", "abc" };

            try
            {
                var stringList = StringManager.Sort(new string[][] { string1, string2, string3 }, SortOrder.Ascending);

                Console.WriteLine("Sorted unique list is:");
                foreach (var item in stringList.SortedUniqueStrings)
                    Console.WriteLine(item);

                Console.WriteLine();

                Console.WriteLine("Duplicate list is:");
                foreach (var item in stringList.DuplicateStrings)
                    Console.WriteLine(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

    }
}


