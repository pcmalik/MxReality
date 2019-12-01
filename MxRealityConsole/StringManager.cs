using MxRealityConsole.Interfaces;
using MxRealityConsole.Models;
using System;
using System.Linq;

namespace MxRealityConsole
{
    public class StringManager
    {
        private readonly ISort _sort;

        public StringManager(ISort sort)
        {
            _sort = sort;
        }

        public StringList Sort(string[][] stringLists, SortOrder sortOrder)
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

            _sort.Sort(sortedUniqueStrings);
            if (sortOrder.Equals(SortOrder.Descending))
                _sort.Reverse(sortedUniqueStrings);

            return new StringList { SortedUniqueStrings = sortedUniqueStrings, DuplicateStrings = duplicateStrings };
        }

    }
}
