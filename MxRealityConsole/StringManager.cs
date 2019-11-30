using MxRealityConsole.Models;
using System;
using System.Linq;

namespace MxRealityConsole
{
    public static class StringManager
    {
        public static StringList Sort(string[][] stringLists, SortOrder sortOrder)
        {
            if (stringLists == null)
                throw new ArgumentNullException("stringLists");

            if ((stringLists.Count() == 0) || (stringLists.Where(x => x != null).Count() == 0))
                throw new ArgumentException("stringLists cannot be empty");

            string[] sortedUniqueStrings = new string[0];
            string[] duplicateStrings = new string[0];

            foreach (var stringList in stringLists)
            {
                foreach (var stringItem in stringList)
                {
                    if (sortedUniqueStrings.Contains(stringItem))
                    {
                        Array.Resize(ref duplicateStrings, duplicateStrings.Length + 1);
                        duplicateStrings[duplicateStrings.Length - 1] = stringItem;
                    }
                    else
                    {
                        Array.Resize(ref sortedUniqueStrings, sortedUniqueStrings.Length + 1);
                        sortedUniqueStrings[sortedUniqueStrings.Length - 1] = stringItem;
                    }
                }
            }

            if (sortedUniqueStrings != null && sortedUniqueStrings.Count() > 0)
            {
                Array.Sort(sortedUniqueStrings);
                if (sortOrder.Equals(SortOrder.Descending))
                    Array.Reverse(sortedUniqueStrings);
            }

            return new StringList { SortedUniqueStrings = sortedUniqueStrings, DuplicateStrings = duplicateStrings };
        }

    }
}
