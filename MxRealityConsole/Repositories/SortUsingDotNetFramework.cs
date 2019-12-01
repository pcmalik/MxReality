using MxRealityConsole.Interfaces;
using System;
using System.Linq;

namespace MxRealityConsole.Repositories
{
    public class SortUsingDotNetFramework : ISort
    {
        public void Sort(string[] stringList)
        {
            if (stringList != null && stringList.Count() > 0)
            {
                Array.Sort(stringList);
            }
        }

        public void Reverse(string[] stringList)
        {
            Array.Reverse(stringList);
        }

    }
}