using MxRealityConsole.Interfaces;
using MxRealityConsole.Models;
using MxRealityConsole.Repositories;
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
                //Change your sorting logic as parameter here...
                var sortingLogic = GetSortingLogic(SortingLogic.BubbleSort);

                var stringManager = new StringManager(sortingLogic);
                var stringList = stringManager.Sort(new string[][] { string1, string2, string3 }, SortOrder.Ascending);

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

        /*
         Note: below factory method design pattern could be used to choose 
         required sorting logic implementation based on configuration settings
        */
        public static ISort GetSortingLogic(SortingLogic logicName)
        {
            if (logicName.Equals(SortingLogic.BubbleSort))
                return new SortUsingBubbleSort();
            else if (logicName.Equals(SortingLogic.DotNetFramework))
                return new SortUsingDotNetFramework();
            else
                throw new Exception("Unknown logic");
        }

    }
}


